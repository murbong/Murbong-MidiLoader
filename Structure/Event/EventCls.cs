using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murbong_MidiLoader.Structure.Event
{

    public abstract class EventCls : IBinaryReadable
    {
        public byte Type { get; set; }
        public int Length { get; set; }
        public byte[] Data { get; set; }
        public virtual void Read(MidiReader mr)
        {
            
        }
    }

    public enum NoteEvent : byte
    {
        Off=0x8,
        On=0x9,
        KeyAfterTouch=0xA,
        PolyphonicAfterTouch = 0xB,
        Program =0xC,
        ChannelAfterTouch=0xD,
        PitchBend=0xE

    }

    public enum ModeEvent : byte
    {
        AllSoundOff = 0x78,
        ResetAll = 0x79,
        LocalControl = 0x7A,
        AllNoteOff = 0x7B,
        OmniOff = 0x7C,
        OmniOn = 0x7D,
        MonoOn = 0x7E,
        PolyOn = 0x7F,

    }

    public enum MetaEvent : byte
    {
        SequenceNum = 0x00,
        Text = 0x01,
        Copyright = 0x02,
        SequenceTrack = 0x03,
        Instrument = 0x04,
        Lyric = 0x05,
        Marker = 0x06,
        CuePoint = 0x07,
        ChannelPrefix = 0x20,
        EndOfTrack = 0x2F,
        SetTempo = 0x51,
        SMPTEOffset = 0x54,
        TimeSignature = 0x58,
        KeySignature = 0x59,
        SequencerData = 0x7F
    }
    public enum System : byte
    {
        SysEx = 0xF0,
        SysEx_Escape = 0xF7
    }
}
