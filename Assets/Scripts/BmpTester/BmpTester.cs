using System;
using System.Collections.Generic;
using Unchord;
using UnityEngine;

public class BmpTester : MonoBehaviour
{
    public string path;

    public bool shouldLoadBmp = false;

    public List<TileSet> tileSets;

    private BmpPixelEditor m_editor;

    [Serializable]
    public struct TileSet
    {
        public byte r;
        public byte g;
        public byte b;
        public Sprite tileSprite;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(shouldLoadBmp)
        {
            shouldLoadBmp = false;

            BmpFile bmpFile = new BmpFile();
            bmpFile.Read(path);
            m_editor = new BmpPixelEditor(bmpFile);

            for(int i = transform.childCount - 1; i >= 0; --i)
                Destroy(transform.GetChild(i).gameObject);      

            int w = bmpFile.InfoHeader.biWidth;
            int h = bmpFile.InfoHeader.biHeight;

            Debug.Log(bmpFile.FileHeader.ToString());
            Debug.Log(bmpFile.InfoHeader.ToString());
            
            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    m_CreateTile(x, y);
                }
            }
        }
    }

    private void m_CreateTile(int _x, int _y)
    {
        RGBQuad rgbQuad = m_editor.GetPixel(_x, _y);

        Debug.LogFormat("RGB == ({0}, {1}, {2})", rgbQuad.rgbRed, rgbQuad.rgbGreen, rgbQuad.rgbBlue);

        for(int i = 0; i < tileSets.Count; ++i)
        {
            if (tileSets[i].r != rgbQuad.rgbRed ||
                tileSets[i].g != rgbQuad.rgbGreen ||
                tileSets[i].b != rgbQuad.rgbBlue
            )
            {
                continue;
            }

            GameObject tileObj = new GameObject(string.Format("Tile ({0}, {1})", _x, _y));
            SpriteRenderer sprnd = tileObj.AddComponent<SpriteRenderer>();

            tileObj.transform.parent = this.transform;
            tileObj.transform.position = new Vector2(_x, _y);
            sprnd.sprite = tileSets[i].tileSprite;
            break;
        }
    }
}
