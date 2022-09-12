using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExerciser
{
    public enum TiffTag : ushort
    {
        ImageWidth = 256,
        ImageLength = 257,
        BitsPerSample = 258,
        Compression = 259,
        Photometric = 262,
        FillOrder = 266,
        StripOffset = 273,
        Orientation = 274,
        SamplesPerPixel = 277,
        RowsPerStrip = 278,
        StripByteCounts = 279,
        XResolution = 282,
        YResolution = 283,
        ResolutionUnit = 296,
        JPEGProc = 512,
        JPEGInterchangeFormat = 513,
        JPEGInterchangeFormatLength = 514,
        JPEGRestartInterval = 515,
        JPEGQTables = 519,
        JPEGDCTables = 520,
        JPEGACTables = 521,
        Unknown33885 = 33885,
        Unknown50701 = 50701
    }
}
