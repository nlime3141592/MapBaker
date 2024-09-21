using System.IO;
using System.Runtime.InteropServices;

namespace Unchord
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BmpInfoHeader
    {
        public uint biSize;          // NOTE: 정보 헤더의 크기
        public int biWidth;          // NOTE: 비트맵의 너비
        public int biHeight;         // NOTE: 비트맵의 높이
        public ushort biPlanes;      // NOTE: 색상 평면의 수 (항상 1)
        public ushort biBitCount;    // NOTE: 픽셀당 비트 수
        public uint biCompression;   // NOTE: 압축 방식
        public uint biSizeImage;     // NOTE: 이미지 데이터의 크기
        public int biXPelsPerMeter;  // NOTE: 가로 해상도
        public int biYPelsPerMeter;  // NOTE: 세로 해상도
        public uint biClrUsed;       // NOTE: 색상 테이블에서 실제 사용되는 색상 수
        public uint biClrImportant;  // NOTE: 중요하게 사용되는 색상 수

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