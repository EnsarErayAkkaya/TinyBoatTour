using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunksGenerator 
{
    private MapSettings mapSettings;
    public MapChunksGenerator(MapSettings mapSettings)
    {
        this.mapSettings = mapSettings;
    }
    public List<MapChunk> GenerateMapChunks(List<Tile> tiles)
    {
        List<MapChunk> mapChunks = new List<MapChunk>();

        int chunkAxisLength = (int)Mathf.Sqrt(mapSettings.chunkLength);

        for (int x = 0; x < mapSettings.width; x += chunkAxisLength)
        {
            for (int z = 0; z < mapSettings.height; z += chunkAxisLength)
            {
                List<Tile> chunkTiles = new List<Tile>();
                int index = (x * mapSettings.width) + z;
                Vector3 chunkCenter = Vector3.zero;
                int centerIndex = Mathf.FloorToInt(chunkAxisLength / 2);
                for (int i = index; i < index + chunkAxisLength; i++)
                {
                    for (int j = 0; j < mapSettings.width * chunkAxisLength; j += mapSettings.width)
                    {
                        chunkTiles.Add(tiles[i + j]);
                        if(i == index + centerIndex && j == centerIndex * mapSettings.width)
                        {
                            
                            chunkCenter = tiles[i + j].transform.position;
                        }
                    }
                }                
                mapChunks.Add(new MapChunk(chunkTiles, chunkCenter, mapChunks.Count));
            }
        }

        return mapChunks;
    }
}
