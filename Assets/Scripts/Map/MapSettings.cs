using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MapSettings : ScriptableObject
{
    public int width;
    public int height;
    public int chunkLength;
    public float tileSideLength;
    public int seed;
    [Range(0,1)]
    public float maxWaterLevel;
    [Range(0,1)]
    public float maxSandLevel;
    [Range(0,1)]
    public float maxGroundLevel;

    public TileSetting[] tileSettings;
}
