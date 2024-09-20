using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class SortingLayerProperty
{
    public string SortingLayerName => SortingLayer.layers.Select(x => x.name).ToArray()[layerIndex];

    public int layerIndex;
}