using System.IO;

namespace Unchord
{
    public class BmpFile
    {
        public BmpFileHeader FileHeader;// { get; set; }
        public BmpInfoHeader InfoHeader;// { get; set; }
        public RGBQuad[] ColorTable;// { get; set; }

        // NOTE: �� ���� ũ�Ⱑ 4����Ʈ�� ������� �ϹǷ� �е� ����Ʈ�� �߰��� �ʿ� ����.
        public byte[] PixelData;// { get; set; }

        public void Read(string _filePath)
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader rd = new BinaryReader(fs))
            {
                FileHeader = new BmpFileHeader();
                FileHeader.Read(rd);

                InfoHeader = new BmpInfoHeader();
                InfoHeader.Read(rd);

                if(InfoHeader.biBitCount <= 8)
                {
                    int clrTableSize = 1 << InfoHeader.biBitCount;

                    ColorTable = new RGBQuad[clrTableSize];

                    for(int i = 0; i < clrTableSize; ++i)
                    {
                        ColorTable[i] = new RGBQuad();
                        ColorTable[i].Read(rd);
                    }
                }

                PixelData = rd.ReadBytes((int)(fs.Length - FileHeader.bfOffBits));
            }
        }

        public void Write(string _filePath)
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter wr = new BinaryWriter(fs))
            {
                FileHeader.Write(wr);
                InfoHeader.Write(wr);

                for (int i = 0; i < (ColorTable?.Length ?? 0); ++i)
                    ColorTable[i].Write(wr);

                wr.Write(PixelData);
            }
        }
    }
}