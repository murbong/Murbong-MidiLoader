using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure.Event
{
    public class Sys : EventCls
    {
        public override void Read(MidiReader mr)
        {
            Length = mr.ReadVLQ();
            Data = mr.ReadBytes(Length);
        }
    }
}
