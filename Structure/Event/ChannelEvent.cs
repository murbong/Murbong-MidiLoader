using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure.Event
{
    class ChannelEvent : EventCls
    {
        public byte Channel { get; set; }
        public byte MidiEvent { get; set; }
        public byte Param1 { get; set; }
        public byte Param2 { get; set; }
        public byte Velocity { get; set; }
        public override void Read(MidiReader mr)
        {

            if ((Type & 0x80) == 0)
            {
                Param1 = Type;
                Type =  TrackData.LastEvent;
            }
            else
            {
                Param1 = mr.ReadByte();
                TrackData.LastEvent = Type;
            }

            Channel = (byte)(Type & 0x0F);
            MidiEvent = (byte)(Type >> 4);


            if (MidiEvent == (byte)NoteEvent.Off || MidiEvent == (byte)NoteEvent.On)
            {
                Velocity = mr.ReadByte();
            }
            else if (MidiEvent == (byte)NoteEvent.KeyAfterTouch || MidiEvent == (byte)NoteEvent.PolyphonicAfterTouch || MidiEvent == (byte)NoteEvent.PitchBend)
            {
                Param2 = mr.ReadByte();
            }
            else if (MidiEvent == (byte)NoteEvent.Program || MidiEvent == (byte)NoteEvent.ChannelAfterTouch)
            {
                //Nothing Here
            }
            else
            {
                throw new FormatException($"Unexpected midiEvent : {MidiEvent.ToString("X2")}");
            }

        }
    }
}
