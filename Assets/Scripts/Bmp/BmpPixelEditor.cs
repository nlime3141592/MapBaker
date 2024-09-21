using System.Diagnostics;

namespace Unchord
{
    public class BmpPixelEditor
    {
        public BmpFile File { get; set; }

        public BmpPixelEditor(BmpFile _file)
        {
            this.File = _file;
        }

        public void SetPixel(int _x, int _y, RGBQuad _rgbQuad)
        {
            this.SetPixel(_x, _y, _rgbQuad.rgbRed, _rgbQuad.rgbGreen, _rgbQuad.rgbBlue);
        }

        public void SetPixel(int _x, int _y, byte _r, byte _g, byte _b)
        {
            Debug.Assert(_x >= 0 && _x < this.File.InfoHeader.biWidth);
            Debug.Assert(_y >= 0 && _y < this.File.InfoHeader.biHeight);

            int offset = m_GetPixelOffset(_x, _y);

            this.File.PixelData[offset] = _b;
            this.File.PixelData[offset + 1] = _g;
            this.File.PixelData[offset + 2] = _r;
        }

        public RGBQuad GetPixel(int _x, int _y)
        {
            Debug.Assert(_x >= 0 && _x < this.File.InfoHeader.biWidth);
            Debug.Assert(_y >= 0 && _y < this.File.InfoHeader.biHeight);

            RGBQuad rgbQuad = new RGBQuad();
            int offset = m_GetPixelOffset(_x, _y);

            rgbQuad.rgbBlue = this.File.PixelData[offset];
            rgbQuad.rgbGreen = this.File.PixelData[offset + 1];
            rgbQuad.rgbRed = this.File.PixelData[offset + 2];

            return rgbQuad;
        }

        private int m_GetPixelOffset(int _x, int _y)
        {
            int w = this.File.InfoHeader.biWidth;
            int h = this.File.InfoHeader.biHeight;

            int bitsPerRow = w * this.File.InfoHeader.biBitCount;
            bitsPerRow += (32 - bitsPerRow % 32) % 32;

            return (_y * (bitsPerRow / 8)) + _x * (this.File.InfoHeader.biBitCount / 8);
        }
    }
}