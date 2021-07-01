using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure.Event
{
    public class Meta : EventCls
    {
        public override void Read(MidiReader mr)
        {
            Type = mr.ReadByte();
            Length = mr.ReadVLQ();
            Data = mr.ReadBytes(Length);
        }
    }
}
