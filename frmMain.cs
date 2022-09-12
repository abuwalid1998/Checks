using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libdocprocsharp;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SimpleExerciser
{
    public partial class frmMain : Form
    {
        private PictureBox[] defaultImages;
        private int defaultImageIndex = 0;
        private DocumentProcessorBase docproc;
        private string endorseini, imageini, readerini;
        private bool isReady = false;
        private Dictionary<uint, Bitmap[]> images = new Dictionary<uint, Bitmap[]>();
        private string crashFile = Environment.TickCount + ".txt", logFile = "Runtime\\traces\\" + Environment.TickCount + ".txt";
        private bool alternatePockets = false;
        private StreamWriter logWriter = null;
        private Thread logThread;
        private Queue<string> logQueue;
        private Queue<IAsyncResult> invokeQueue;
        private object lockLog = new object(), lockInvoke = new object();
        private AutoResetEvent logEvent;//use for log and GUI invoke
        private StringBuilder logMessages;
        private bool formShown = false;
        public frmMain()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += (o, e) => { File.AppendAllText(crashFile, e.ExceptionObject.ToString()); };
            logQueue = new Queue<string>();
            invokeQueue = new Queue<IAsyncResult>();
            logEvent = new AutoResetEvent(false);
            logMessages = new StringBuilder();
            logThread = new Thread(() =>
            {
                while (true)
                {
                    logEvent.WaitOne(1 * 1000);//block until signaled
                    if (formShown)
                    {
                        int prevSize = logMessages.Length;
                        while (logQueue.Count > 0)//get multiple log messages togther for 1 invoke
                        {
                            string log;
                            lock (lockLog)
                                log = logQueue.Dequeue();
                            logMessages.Insert(0, string.Format("[{0}]: {1}{2}", DateTime.Now, log, Environment.NewLine));
                        }
                        if (prevSize < logMessages.Length)
                        {
                            DateTime begin = DateTime.Now;
                            lock (lockInvoke)
                                invokeQueue.Enqueue(BeginInvoke((MethodInvoker)delegate
                                {
                                    txtLog.Text = logMessages.ToString();
                                }));
                            System.Diagnostics.Debug.WriteLine("Logging: " + (DateTime.Now - begin).TotalMilliseconds);
                        }
                        while (invokeQueue.Count > 0)
                        {
                            IAsyncResult res;
                            lock (lockInvoke)
                                res = invokeQueue.Dequeue();
                            try
                            {
                                if (formShown)
                                    EndInvoke(res);
                            }
                            catch (ObjectDisposedException ode){ }//ignore form disposed
                            catch (Exception ex)//log real stuff
                            {
                                File.AppendAllText(crashFile, ex.ToString());
                            }
                        }
                    }
                }
            });
            logThread.IsBackground = true;
            logThread.Start();
            //logWriter = new StreamWriter(File.OpenWrite(logFile));
            ExtractResources();
            defaultImages = new PictureBox[] { picFront1, picFront2, picRear1, picRear2, picSnip };
            picFront1.Click += (s, e) => { defaultImageIndex = 0; picLarge.Image = defaultImages[defaultImageIndex].Image; };
            picFront2.Click += (s, e) => { defaultImageIndex = 1; picLarge.Image = defaultImages[defaultImageIndex].Image; };
            picRear1.Click += (s, e) => { defaultImageIndex = 2; picLarge.Image = defaultImages[defaultImageIndex].Image; };
            picRear2.Click += (s, e) => { defaultImageIndex = 3; picLarge.Image = defaultImages[defaultImageIndex].Image; };
            picSnip.Click += (s, e) => { defaultImageIndex = 4; picLarge.Image = defaultImages[defaultImageIndex].Image; };
            chkAlternatePockets.CheckedChanged += (s, e) => { alternatePockets = chkAlternatePockets.Checked; };
            Log("SimpleExerciser loaded. Default image set to {0}.", 0);
        }

        private delegate void LogDelegate(string format, params object[] args);
        private void Log(string format, params object[] args)
        {
            //logWriter.WriteLine(format, args);
            lock (lockLog)
            {
                logQueue.Enqueue(string.Format(format, args));
                logEvent.Set();
            }
        }

        private void Log(Exception ex)
        {
            Log("Unhandled Exception: {0} at {1}.{2}", ex.Message, ex.StackTrace, Environment.NewLine);
        }

        private void ExtractResources()
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            File.WriteAllText(endorseini = Path.Combine(basePath, "endorse.ini"), SimpleExerciser.Properties.Resources.endorse);
            File.WriteAllText(imageini = Path.Combine(basePath, "image.ini"), SimpleExerciser.Properties.Resources.image);
            File.WriteAllText(readerini = Path.Combine(basePath, "reader.ini"), SimpleExerciser.Properties.Resources.reader);
        }

        private unsafe void btnConnectStart_Click(object sender, EventArgs e)
        {
            docproc = DocumentProcessorBase.CurrentDocumentProcessor;
            docproc.Connected += (d) =>
                {
                    Log("Track connected: {0}", docproc.Handle);
                };
            docproc.PoweringUp += (d) =>
                {
                    Log("Device powering up: {0}", docproc.Handle.DeviceName);
                };
            docproc.PoweredUp += (d) =>
                {
                    Log("Device powered up: {0}", docproc.Handle.DeviceName);
                    docproc.iEndFontSetup = endorseini;
                    docproc.iImgCarSetupFilePath = imageini;
                    docproc.iRdrFontLoadPath = readerini;
                    DpError err = docproc.GoReadyToProcess();
                    if (err != DpError.Success)
                        Log("Error when trying to GoReadyToProcess: {0}", err);
                };
            docproc.Readying += (d) =>
                {
                    Log("Device readying: {0}", docproc.Handle.DeviceName);
                };
            docproc.ReadyToProcess += (d) =>
                {
                    Log("Device ready: {0}", docproc.Handle.DeviceName);
                    Log("Starting flow for device {0}.", docproc.Handle.DeviceName);
                    DpError err = docproc.FlowStart(FlowMode.AutoFeed);
                    if (err != DpError.Success)
                        Log("Error when trying to FlowStart: {0}", err);
                    isReady = true;
                };
            docproc.Idle += (d) =>
                {
                    Log("Device in idle: {0}", docproc.Handle.DeviceName);
                    docproc.PowerDown();
                };
            docproc.PoweredDown += (d) =>
                {
                    Log("Device powered down: {0}", docproc.Handle.DeviceName);
                    isReady = false;
                };
            docproc.Warning += (d) =>
                {
                    Log("Device {0} warning: {1}", docproc.Handle.DeviceName, docproc.wAlert);
                };
            docproc.ExceptionInProgress += (d) =>
                {
                    Log("Device exception in progress: {0}", docproc.Handle.DeviceName);
                };
            docproc.ExceptionComplete += (d) =>
                {
                    Log("Device exception complete: {0}", docproc.Handle.DeviceName);
                };
            docproc.FlowStopped += (d) =>
                {
                    Log("Flow stopped for device {0}.", docproc.Handle.DeviceName);
                    docproc.GoIdle();
                };
            docproc.Disconnected += (d) =>
                {
                    Log("Device {0} disconnected.", docproc.Handle.DeviceName);
                };
            docproc.DocComplete += (d) =>
                {
                    Log("DocComplete {0}.", docproc.Handle.DeviceName);
                    if ((bool)Invoke((Func<bool>)delegate() { return chkShowImages.Checked; }))
                    {
                        Bitmap[] bitmaps;
                        if (images.TryGetValue(docproc.cAppDocDIN, out bitmaps))
                        {
                            DateTime begin = DateTime.Now;
                            lock (lockInvoke)
                                invokeQueue.Enqueue(BeginInvoke((MethodInvoker)delegate()
                                {
                                    picFront1.Image = bitmaps[0];
                                    picFront2.Image = bitmaps[1];
                                    picRear1.Image = bitmaps[2];
                                    picRear2.Image = bitmaps[3];
                                    picSnip.Image = bitmaps[4];
                                    picLarge.Image = defaultImages[defaultImageIndex].Image;
                                }));
                            images.Remove(docproc.cAppDocDIN);
                            System.Diagnostics.Debug.WriteLine("Display images: " + (DateTime.Now - begin).TotalMilliseconds);
                        }
                    }
                };
            docproc.DocImageComplete += (d) =>
                {
                    if ((bool)Invoke((Func<bool>)delegate() { return chkShowImages.Checked; }))
                    {
                        Bitmap[] bitmaps;
                        if (!images.TryGetValue(docproc.imgDocId, out bitmaps))
                        {
                            bitmaps = new Bitmap[5];
                            images[docproc.imgDocId] = bitmaps;
                        }
                        DateTime begin = DateTime.Now;
                        if (docproc.img1FrontSize > 0)
                        {
                            try
                            {
                                bitmaps[0] = TiffHelper.TryFromData(new BinaryReader(new UnmanagedMemoryStream((byte*)docproc.img1FrontPtr.ToPointer(), docproc.img1FrontSize)).ReadBytes((int)docproc.img1FrontSize)) as Bitmap;
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(crashFile, ex.ToString());
                            }
                        }
                        if (docproc.img2FrontSize > 0)
                            try
                            {
                                bitmaps[1] = TiffHelper.TryFromData(new BinaryReader(new UnmanagedMemoryStream((byte*)docproc.img2FrontPtr.ToPointer(), docproc.img2FrontSize)).ReadBytes((int)docproc.img2FrontSize)) as Bitmap;
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(crashFile, ex.ToString());
                            }
                        if (docproc.img1RearSize > 0)
                            try
                            {
                                bitmaps[2] = TiffHelper.TryFromData(new BinaryReader(new UnmanagedMemoryStream((byte*)docproc.img1RearPtr.ToPointer(), docproc.img1RearSize)).ReadBytes((int)docproc.img1RearSize)) as Bitmap;
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(crashFile, ex.ToString());
                            }
                        if (docproc.img2RearSize > 0)
                            try
                            {
                                bitmaps[3] = TiffHelper.TryFromData(new BinaryReader(new UnmanagedMemoryStream((byte*)docproc.img2RearPtr.ToPointer(), docproc.img2RearSize)).ReadBytes((int)docproc.img2RearSize)) as Bitmap;
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(crashFile, ex.ToString());
                            }
                        if (docproc.img2RearSize > 0)
                            try
                            {
                                bitmaps[4] = TiffHelper.TryFromData(new BinaryReader(new UnmanagedMemoryStream((byte*)docproc.imgSnippetPtr.ToPointer(), docproc.imgSnippetSize)).ReadBytes((int)docproc.imgSnippetSize)) as Bitmap;
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(crashFile, ex.ToString());
                            }
                        System.Diagnostics.Debug.WriteLine("Images: " + (DateTime.Now - begin).TotalMilliseconds);
                    }
                };
            docproc.DocImageSnippetComplete += (d) =>
                {
                };
            docproc.DocReadComplete += (d) =>
                {
                    Log("DocReadComplete: {0}", docproc.Handle.DeviceName);
                    string codeline;
                    Log("Codeline: {0}", codeline = docproc.rRdr1CodeLine ?? docproc.rRdr2CodeLine ?? docproc.rRdr3CodeLine);
                    lock (lockInvoke)
                        invokeQueue.Enqueue(BeginInvoke((MethodInvoker)delegate() { lblMicr.Text = codeline; }));
                    docproc.pEndRearFontNumber = 0;
                    docproc.pEndRearLogoNumber = 0;
                    docproc.pEndRearOptions = 0;//?
                    docproc.pEndRearPosition = 0;//?
                    docproc.pImgCarDocType = 0;
                    docproc.pImgOptions = 0x4f;//?
                    if (alternatePockets)
                        docproc.pStkPocket = ((docproc.pStkPocket) % 2) + 1;//1 or 2. 0 is forced jam
                    else if (docproc.pStkPocket == 0)
                        docproc.pStkPocket = 1;
                    //docproc.pAppDocData = System.Text.ASCIIEncoding.ASCII.GetBytes(codeline);
                    docproc.pAppDocDIN = docproc.rRdrDocId;
                    docproc.pSorterId = 0;
                    docproc.pStmpOptions = 0;//?
                    docproc.DocAccept();
                    docproc.DocProcess();
                };
            if (!isReady)
            {
                Log("PowerUp requested.");
                docproc.PowerUp();
            }
            else
            {
                docproc.FlowStart(FlowMode.AutoFeed);
            }
        }

        private void btnStopDisconnect_Click(object sender, EventArgs e)
        {
            Log("Stop/Disconnect requested.");
            docproc = DocumentProcessorBase.CurrentDocumentProcessor;
            docproc.FlowStop();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            formShown = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            formShown = false;
        }
    }
}
