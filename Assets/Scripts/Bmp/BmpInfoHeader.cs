using System.IO;
using System.Runtime.InteropServices;

namespace Unchord
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BmpInfoHeader
    {
        public uint biSize;          // NOTE: ���� ����� ũ��
        public int biWidth;          // NOTE: ��Ʈ���� �ʺ�
        public int biHeight;         // NOTE: ��Ʈ���� ����
        public ushort biPlanes;      // NOTE: ���� ����� �� (�׻� 1)
        public ushort biBitCount;    // NOTE: �ȼ��� ��Ʈ ��
        public uint biCompression;   // NOTE: ���� ���
        public uint biSizeImage;     // NOTE: �̹��� �������� ũ��
        public int biXPelsPerMeter;  // NOTE: ���� �ػ�
        public int biYPelsPerMeter;  // NOTE: ���� �ػ�
        public uint biClrUsed;       // NOTE: ���� ���̺��� ���� ���Ǵ� ���� ��
        public uint biClrImportant;  // NOTE: �߿��ϰ� ���Ǵ� ���� ��

        public override string ToString()
        {
            return $"Bitmap Info Header:\n" +
                   $"  Size: {biSize}\n" +
                   $"  Width: {biWidth}\n" +
                   $"  Height: {biHeight}\n" +
                   $"  Planes: {biPlanes}\n" +
                   $"  Bit Count: {biBitCount}\n" +
                   $"  Compression: {biCompression}\n" +
                   $"  Size of Image: {biSizeImage}\n" +
                   $"  X Pixels Per Meter: {biXPelsPerMeter}\n" +
                   $"  Y Pixels Per Meter: {biYPelsPerMeter}\n" +
                   $"  Colors Used: {biClrUsed}\n" +
                   $"  Important Colors: {biClrImportant}";
        }

        public void Read(BinaryReader _reader)
        {
            biSize = _reader.ReadUInt32();
            biWidth = _reader.ReadInt32();
            biHeight = _reader.ReadInt32();
            biPlanes = _reader.ReadUInt16();
            biBitCount = _reader.ReadUInt16();
            biCompression = _reader.ReadUInt32();
            biSizeImage = _reader.ReadUInt32();
            biXPelsPerMeter = _reader.ReadInt32();
            biYPelsPerMeter = _reader.ReadInt32();
            biClrUsed = _reader.ReadUInt32();
            biClrImportant = _reader.ReadUInt32();
        }

        public void Write(BinaryWriter _writer)
        {
            _writer.Write(biSize);
            _writer.Write(biWidth);
            _writer.Write(biHeight);
            _writer.Write(biPlanes);
            _writer.Write(biBitCount);
            _writer.Write(biCompression);
            _writer.Write(biSizeImage);
            _writer.Write(biXPelsPerMeter);
            _writer.Write(biYPelsPerMeter);
            _writer.Write(biClrUsed);
            _writer.Write(biClrImportant);
        }
    }
}