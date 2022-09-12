using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExerciser
{
    public class TiffIfd
    {
        public ushort entryCount;///Probably redundant, but including anyway
        public List<TiffIfdEntry> IfdEntries;///The entries of the IFD
		public uint nextIfdOffset;///Will most always be zero (0)
        //public TiffIfd NextIfd = null;///Next Ifd, usually null
        public TiffIfd(ushort entryCount, List<TiffIfdEntry> ifdEntries, uint nextIfdOffset)
        {
			this.entryCount = entryCount;
            this.IfdEntries = ifdEntries;
            this.nextIfdOffset = nextIfdOffset;
		}

        public TiffIfd()
        {
            entryCount = 0;
            IfdEntries = new List<TiffIfdEntry>();
            nextIfdOffset = 0;
        }

        public TiffIfdEntry this[int index]
        {
            get
            {
                return IfdEntries[index];
            }
        }

        public override string ToString()
        {
            return String.Format("{{Count {0}, Next Offset {1}}}", entryCount, nextIfdOffset);
        }

        public TiffIfdEntry FindByTag(TiffTag tag)
        {
            foreach (TiffIfdEntry entry in IfdEntries)
                if (entry.tag == tag)
                    return entry;
            return null;
        }
    }
}
