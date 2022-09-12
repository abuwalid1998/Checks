using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExerciser
{
    public class TiffHeader
    {
        public static ushort byteOrder = 0x4949;
		public static ushort fortyTwo = 42;//heh
		public uint   IFDOffset;

		public TiffHeader(uint IFDOffset)
        {
			this.IFDOffset = IFDOffset;
		}
        public ushort ByteOrder
        {
            get
            {
                return byteOrder;
            }
        }
        public ushort FortyTwo
        {
            get
            {
                return fortyTwo;
            }
        }
    }
}
