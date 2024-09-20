using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
[DisallowMultipleComponent]
[Serializable]
public class MapOrderManager : MonoBehaviour
{
    public int sortingLayerIndex;

    public int sortingOrderOffset = 0;
    public float sortingPositionOffsetZ = 0.0f;
    [Range(0.001f, 3.0f)] public float sortingPositionDeltaZ = 0.01f;
    public SortingDirection sortingDirection = SortingDirection.Ascending;
    public SortingType sortingType = SortingType.SortingOrderNumber;

    public enum SortingType : int
    {
        SortingOrderNumber,
        PositionZ
    }

    public enum SortingDirection : int
    {
        Ascending = 1,
        Descending = -1
    }

    private void Update()
    {
        if (sortingType == SortingType.SortingOrderNumber)
            m_rec_UpdateByOrder(this.transform, sortingOrderOffset);
        else
            m_rec_UpdateByPositionZ(this.transform, sortingPositionOffsetZ);
    }

    private int m_rec_UpdateByOrder(Transform _parent, int _orderNumber)
    {
        SpriteRenderer[] sprnds = _parent.GetComponents<SpriteRenderer>();

        for(int i = 0; i < sprnds.Length; ++i)
        {
            Vector3 pos = sprnds[i].transform.position;
            pos.z = sortingPositionOffsetZ;

            sprnds[i].sortingLayerName = SortingLayer.layers.Select(x => x.name).ToArray()[sortingLayerIndex];
            sprnds[i].sortingOrder = _orderNumber;
            _orderNumber += (int)this.sortingDirection;
            sprnds[i].transform.position = pos;
        }

        if (_parent.childCount == 0)
            return _orderNumber;

        for (int i = 0; i < _parent.childCount; ++i)
        {
            Transform child = _parent.GetChild(i);

            if (child.TryGetComponent<MapOrderManager>(out _))
                continue;
            else
                _orderNumber = m_rec_UpdateByOrder(child, _orderNumber);
        }

        return _orderNumber;
    }

    private float m_rec_UpdateByPositionZ(Transform _parent, float _positionZ)
    {
        SpriteRenderer[] sprnds = _parent.GetComponents<SpriteRenderer>();

        for(int i = 0;i < sprnds.Length; ++i)
        {
            Vector3 pos = sprnds[i].transform.position;
            pos.z = _positionZ;
            _positionZ -= (float)sortingDirection * sortingPositionDeltaZ;

            sprnds[i].sortingLayerName = SortingLayer.layers.Select(x => x.name).ToArray()[sortingLayerIndex];
            sprnds[i].sortingOrder = this.sortingOrderOffset;
            sprnds[i].transform.position = pos;
        }

        if (_parent.childCount == 0)
            return _positionZ;

        for(int i = 0; i < _parent.childCount; ++i)
        {
            Transform child = _parent.GetChild(i);

            if (child.TryGetComponent<MapOrderManager>(out _))
                continue;
            else
                _positionZ = m_rec_UpdateByPositionZ(child, _positionZ);
        }

        return _positionZ;
    }
}
