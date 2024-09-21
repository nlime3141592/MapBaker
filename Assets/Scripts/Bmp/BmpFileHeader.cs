using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Unchord
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BmpFileHeader
    {
        public ushort bfType;       // NOTE: 파일 타입 ("BM")
        public uint bfSize;         // NOTE: 파일의 전체 크기
        public ushort bfReserved1;  // NOTE: 예약된 필드 (항상 0)
        public ushort bfReserved2;  // NOTE: 예약된 필드 (항상 0)
        public uint bfOffBits;      // NOTE: 비트맵 데이터가 시작되는 위치

        public override string ToString()
        {
            return $"Bitmap File Header:\n" +
                   $"  Type: {Encoding.ASCII.GetString(new byte[] { (byte)(bfType & 0xFF), (byte)((bfType >> 8) & 0xFF) })}\n" +
                   $"  Size: {bfSize}\n" +
                   $"  Reserved1: {bfReserved1}\n" +
                   $"  Reserved2: {bfReserved2}\n" +
                   $"  Offset Bits: {bfOffBits}";
        }

        public void Read(BinaryReader _reader)
        {
            bfType = _reader.ReadUInt16();
            bfSize = _reader.ReadUInt32();
            bfReserved1 = _reader.ReadUInt16();
            bfReserved2 = _reader.ReadUInt16();
            bfOffBits = _reader.ReadUInt32();
        }

        public void Write(BinaryWriter _writer)
        {
            _writer.Write(bfType);
            _writer.Write(bfSize);
            _writer.Write(bfReserved1);
            _writer.Write(bfReserved2);
            _writer.Write(bfOffBits);
        }
    }
}