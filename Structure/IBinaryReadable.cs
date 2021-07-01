using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure
{
    public interface IBinaryReadable
    {
        void Read(MidiReader mr);
    }
}
