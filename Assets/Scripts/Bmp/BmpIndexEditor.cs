using System;

namespace Unchord
{
    /// <summary>
    /// Color Table을 사용하는 BMP 파일 편집기 클래스입니다.
    /// </summary>
    [Obsolete("필요할 때 구현하세요.")]
    public class BmpIndexEditor
    {
        /*
        public BmpFile File { get; private set; }

        public BmpIndexEditor(string _filePath)
        {
            BmpFile file = new BmpFile();
            file.Read(_filePath);

            this.File = file;
        }

        public BmpIndexEditor(BmpFile _file)
        {
            this.File = _file;
        }

        public void SetColor(int _index, byte _r, byte _g, byte _b)
        {
            this.File.ColorTable[_index].rgbRed = _r;
            this.File.ColorTable[_index].rgbGreen = _g;
            this.File.ColorTable[_index].rgbBlue = _b;
        }

        public RGBQuad GetColor(int _index)
        {
            return File.ColorTable[_index];
        }

        public void Read(string _filePath)
        {
            this.File.Read(_filePath);
        }

        public void Write(string _filePath)
        {
            this.File.Write(_filePath);
        }
        */
    }
}