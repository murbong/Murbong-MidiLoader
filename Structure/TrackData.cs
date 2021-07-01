using Murbong_MidiLoader.Structure.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure
{
    public class TrackData : IBinaryReadable
    {
        public int Length { get; set; }
        public byte[] Buffer { get; set; }
        public static byte LastEvent { get; set; }
        public Dictionary<int, List<EventCls>> Events { get; set; }
        public TrackData()
        {
            Events = new Dictionary<int, List<EventCls>>();
            LastEvent = 0x0;
        }

        public void AddEvent(int time, EventCls evt)
        {
            if (!Events.ContainsKey(time))
            {
                Events.Add(time, new List<EventCls>());
            }
            Events[time].Add(evt);
        }



        public void ShowEvents()
        {
            var item = Events.OrderBy(e => e.Key);
            foreach (var i in item)
            {
                Console.WriteLine(i.Key);
                i.Value.ForEach(e => Console.Write("{0:X} ", e.Type));
                Console.WriteLine();
            }
        }

        public void Read(MidiReader mr)
        {
            Buffer = mr.ReadBytes(Length);
        }

        public void Parse()
        {
            using (var ms = new MemoryStream(Buffer))
            {
                using (var mr = new MidiReader(ms))
                {
                    while (ms.Position != ms.Length)
                    {
                        int deltaTime = mr.ReadVLQ();
                        byte eventStatus = mr.ReadByte();

                        if (eventStatus == 0xFF) // Meta Event
                        {
                            var meta = new Meta();
                            meta.Read(mr);
                            AddEvent(deltaTime, meta);
                        }
                        else if (eventStatus == 0xF0 || eventStatus == 0xF7) // System Event
                        {
                            var sys = new Sys { Type = eventStatus };
                            sys.Read(mr);
                            AddEvent(deltaTime, sys);
                        }
                        else if (eventStatus > 0x7F && eventStatus < 0xF0) // Note Event
                        {
                            var channelEvent = new ChannelEvent { Type = eventStatus };
                            channelEvent.Read(mr);

                            AddEvent(deltaTime, channelEvent);
                        }
                    }
                }
                
            }
            Buffer = null;
        }
    }
}
