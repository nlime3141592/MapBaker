using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Unchord
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BmpFileHeader
    {
        public ushort bfType;       // NOTE: ���� Ÿ�� ("BM")
        public uint bfSize;         // NOTE: ������ ��ü ũ��
        public ushort bfReserved1;  // NOTE: ����� �ʵ� (�׻� 0)
        public ushort bfReserved2;  // NOTE: ����� �ʵ� (�׻� 0)
        public uint bfOffBits;      // NOTE: ��Ʈ�� �����Ͱ� ���۵Ǵ� ��ġ

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