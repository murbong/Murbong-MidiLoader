using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure
{
    public class Header : IBinaryReadable
    {
        public short Format { get; set; }
        public short Tracks { get; set; }
        public short TimeDivision { get; set; }
        public void Read(MidiReader mr)
        {

            Format = mr.BigEndianReadInt16();

            Tracks = mr.BigEndianReadInt16();

            TimeDivision = mr.BigEndianReadInt16();
        }

        public override string ToString()
        {
            return $"{Format} Tracks : {Tracks} TDivision : {TimeDivision}";
        }
    }
}
