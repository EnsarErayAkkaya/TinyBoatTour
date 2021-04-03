using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileSetting
{   
    public TileType tileType;
    public Material material;
}
public enum TileType { Water, Sand, Ground }
