using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{
    private MapSettings mapSettings;
    public MapGenerator(MapSettings mapSettings)
    {
        this.mapSettings = mapSettings;
    }

    public List<Tile> GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapSettings.width, mapSettings.height, .3f);
        List<Tile> tiles = new List<Tile>();
        Vector3 pos = Vector3.zero;
        for (int x = 0; x < mapSettings.width; x++)
        {
            for (int z = 0; z < mapSettings.height; z++)
            {
                pos.x = x * mapSettings.tileSideLength;
                pos.z = z * mapSettings.tileSideLength;

                TileSetting ts = GetTileSetting(noiseMap[x,z]);

                tiles.Add(TileGenerator.CreateTile(pos, ts, mapSettings.tileSideLength));
            }
        }
        return tiles;
    }

    private TileSetting GetTileSetting(float v)
    {
        if(v <= mapSettings.maxWaterLevel)
        {
            return mapSettings.tileSettings[0];
        }
        else if (v <= mapSettings.maxSandLevel)
        {
            return mapSettings.tileSettings[1];
        }
        else if (v <= mapSettings.maxGroundLevel)
        {
            return mapSettings.tileSettings[2];
        }
        else 
            return mapSettings.tileSettings[0];
    }
}
