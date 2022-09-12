using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleExerciser
{
    public static class TiffHelper
    {
        /// <summary>
        /// Returns an Image that does not contain TIFF data, will try standard TIFF reading,
        /// then will try manual seeking to read color JPEGs
        /// </summary>
        /// <param name="raw">Raw TIFF data</param>
        /// <returns>(Memory)Stream</returns>
        public static Image TryFromData(byte[] raw)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(raw))
                {
                    Image image = System.Drawing.Image.FromStream(stream);
                    return image;//get to here, stream is good
                }
            }
            catch (Exception ex)
            {
                try
                {
                    uint jpegOffset = 0;

                    foreach (TiffIfdEntry entry in GetTiffInfo(raw).IfdEntries)
                        if (entry.tag == TiffTag.StripOffset)
                        {
                            jpegOffset = entry.valueOrOffset;
                            break;
                        }
                    if (jpegOffset != 0)
                    {
                        byte[] jpeg = new byte[raw.Length - jpegOffset];
                        Array.Copy(raw, jpegOffset, jpeg, 0, jpeg.Length);
                        return Image.FromStream(new MemoryStream(jpeg));
                    }
                    else return null;
                }
                catch (Exception ex2)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns the various TiffTag/TiffDataType tags
        /// </summary>
        /// <param name="raw">Raw Tiff image data, including headers</param>
        /// <returns></returns>
        public static TiffIfd GetTiffInfo(byte[] raw)
        {
            TiffIfd ifd = new TiffIfd();
            using (BinaryReader reader = new BinaryReader(new MemoryStream(raw)))
            {
                reader.BaseStream.Seek(2, SeekOrigin.Begin);
                if (reader.ReadInt16() == 42)
                {
                    int ifdOffset = reader.ReadInt32();
                    reader.BaseStream.Seek(ifdOffset, SeekOrigin.Begin);
                    ifd.entryCount = reader.ReadUInt16();
                    for (uint i = 0; i < ifd.entryCount && i < 65535; i++)//12 bytes at a time
                    {
                        TiffTag tagId = (TiffTag)reader.ReadUInt16();
                        TiffDataType dataType = (TiffDataType)reader.ReadUInt16();
                        uint dataCount = reader.ReadUInt32();
                        uint dataOffset = reader.ReadUInt32();
                        ifd.IfdEntries.Add(new TiffIfdEntry(tagId, dataType, dataCount, dataOffset));
                    }
                }
                else
                {
                }
            }
            return ifd;
        }

        public static Image GetResizedImage(Bitmap orig, int width, int height)
        {
            try
            {
                return orig.GetThumbnailImage(width, height, null, IntPtr.Zero);
            }
            catch (OutOfMemoryException oome)
            {
                Bitmap image = new Bitmap(width, height);
                float everyn = orig.Width / (float)width;
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                        image.SetPixel(i, j, orig.GetPixel((int)(i * everyn), (int)(j * everyn)));
                return image;
            }
        }
    }
}
