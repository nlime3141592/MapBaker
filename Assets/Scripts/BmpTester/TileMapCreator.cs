using UnityEngine;

namespace Unchord
{
    public class TileMapCreator
    {
        private Transform m_mapTransform;
        private Transform m_tileTransform;
        private Transform m_colliderTransform;

        public TileMapCreator(string _filePath, Transform _mapTransform)
        {
            BmpFile bmpFile = new BmpFile();
            bmpFile.Read(_filePath);

            BmpPixelEditor pxEditor = new BmpPixelEditor(bmpFile);

            m_mapTransform = _mapTransform;
            m_tileTransform = _mapTransform.Find("Renderers/Tile Sprites");
            m_colliderTransform = _mapTransform.Find("Colliders/Tile Colliders");
        }
    }
}