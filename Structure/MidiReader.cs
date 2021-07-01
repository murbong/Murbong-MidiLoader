using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Murbong_MidiLoader.Structure
{
    public class MidiReader : BinaryReader
    {
        public MidiReader(Stream stream) : base(stream)
        {
        }
        public string ReadString(int length)
        {
            return Encoding.ASCII.GetString(ReadBytes(length));
        }
        public int BigEndianReadInt32()
        {
            byte[] buf = ReadBytes(4);
            return (buf[0] << 24) | (buf[1] << 16) | (buf[2] << 8) | buf[3];
        }
        public short BigEndianReadInt16()
        {
            byte[] buf = ReadBytes(2);
            return (short)((buf[0] << 8) | buf[1]);
        }
        public int ReadVLQ()
        {
            int res = 0;

            for (int i = 0; i < 7; i++)
            {
                int c = ReadByte();
                res <<= 7;
                res |= (c & 0x7F);
                if ((c & 0x80) != 0x80)
                {
                    return res;
                }
            }
            return res;
        }

    }
}
