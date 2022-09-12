using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExerciser
{
    public class TiffIfdEntry
    {
        public TiffTag tag;
		public TiffDataType type;
		public uint   valueCount;
		public uint   valueOrOffset;
        public TiffIfdEntry(TiffTag tag, TiffDataType type, uint valueCount, uint valueOrOffset)
        {
			this.tag = tag;
            this.type = type;
            this.valueCount = valueCount;
            this.valueOrOffset = valueOrOffset;
		}

        public override string ToString()
        {
            return string.Format("{{Tag {0}, Type {1}, Count {2}, Value or offset {3}}}", tag, type, valueCount, valueOrOffset);
        }
    }
}
