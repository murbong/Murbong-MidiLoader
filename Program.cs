using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var Midi = new MIDI("./hello.mid");

            Midi.ShowSummary();
        }
    }
}
