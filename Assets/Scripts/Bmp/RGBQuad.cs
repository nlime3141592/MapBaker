using System.IO;
using System.Runtime.InteropServices;

namespace Unchord
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RGBQuad
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;

        public void Read(BinaryReader _reader)
        {
            rgbBlue = _reader.ReadByte();
            rgbGreen = _reader.ReadByte();
            rgbRed = _reader.ReadByte();
            rgbReserved = _reader.ReadByte();
        }

        public void Write(BinaryWriter _writer)
        {
            _writer.Write(rgbBlue);
            _writer.Write(rgbGreen);
            _writer.Write(rgbRed);
            _writer.Write(rgbReserved);
        }
    }
}