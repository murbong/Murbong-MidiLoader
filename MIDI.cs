using Murbong_MidiLoader.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader
{
    public class MIDI
    {

        private string file;
        private MemoryStream ms;

        public Header Header { get; set; }
        public List<TrackData> TrackDatas { get; set; }

        public MIDI(string _file)
        {
            file = _file;
            ms = new MemoryStream();
            Header = new Header();
            TrackDatas = new List<TrackData>();
            Initialize();
        }

        public void Initialize()
        {
            using (var fs = new FileStream(file, FileMode.Open))
            {

                fs.CopyTo(ms);
            }
            var mr = new MidiReader(ms);

            mr.BaseStream.Position = 0;
            while (mr.BaseStream.Position != mr.BaseStream.Length)
            {
                var Type = mr.ReadString(4);
                var Length = mr.BigEndianReadInt32();
                if (Type == "MThd")
                {
                    Header.Read(mr);
                }
                else if (Type == "MTrk")
                {
                    var trackData = new TrackData { Length = Length };
                    trackData.Read(mr);
                    trackData.Parse();
                    TrackDatas.Add(trackData);
                }
                else
                {
                    throw new FormatException("Invalid file header (expected MThd)");
                }
            }
        }
        public void ShowSummary()
        {
            Console.WriteLine("{0} {1}",
            Header.TimeDivision & 0x7FFF, TrackDatas.Count);
        }
        public void Play()
        {

        }
    }
}
