using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExerciser
{
    public enum TiffDataType : ushort
    {
        Byte = 1,
        ASCII = 2,
        Short = 3,
        Long = 4,
        Rational = 5,
        Sbyte = 6,
        Undefine = 7,
        SShort = 8,
        SLong = 9,
        SRational = 10,
        Float = 11,
        Double = 12
    }
}
