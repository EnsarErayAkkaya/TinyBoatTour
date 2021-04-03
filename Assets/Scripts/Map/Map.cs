using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Map : MonoBehaviour
{
    public MapSettings mapSettings;
    public List<MapChunk> mapChunks;
    public Camera cam;

    public Transform player;

    private MapGenerator mapGenerator;
    private MapChunksGenerator mapChunksGenerator;

    private float chunkActivateDistance;
    private float sqrtChunkLegth;
    private int chunksWidthCount;
    private void Start()
    {
        PRNG prng = new PRNG(mapSettings.seed);
        mapGenerator = new MapGenerator(mapSettings);
        mapChunksGenerator = new MapChunksGenerator(mapSettings);

        sqrtChunkLegth = Mathf.Sqrt(mapSettings.chunkLength);
        chunksWidthCount = (int)(mapSettings.width / sqrtChunkLegth);
        chunkActivateDistance = (mapSettings.tileSideLength * sqrtChunkLegth) * 2;

        mapChunks = mapChunksGenerator.GenerateMapChunks(mapGenerator.GenerateMap());

        foreach (var item in mapChunks)
        {
            item.HideAllTiles();
        }
    }
    private void Update()
    {
        //CheckAllChunksBasedOnDistance();
        CheckActiveAndNeighbourChunks();
    }
    private void CheckAllChunksBasedOnDistance()
    {
        for (int i = 0; i < mapChunks.Count; i++)
        {
            if (Vector3.Distance(player.position, mapChunks[i].center) <= chunkActivateDistance)
            {
                // mapChunks[i].ShowTilesInScreen(cam);
                if (!mapChunks[i].active)
                    mapChunks[i].ShowAllTiles();
            }
            else
            {
                if (mapChunks[i].active == true)
                    mapChunks[i].HideAllTiles();
            }
        }
    }
    private void CheckActiveAndNeighbourChunks()
    {
        MapChunk center = GetActiveChunk();
        List<MapChunk> chunks = GetChunkNeighbours(center);

        chunks.Add(center);

        foreach (MapChunk item in mapChunks.ToList().Except(chunks).ToList())
        {
            if (item.active)
                item.HideAllTiles();
        }
        foreach (MapChunk item in chunks)
        {
            if (!item.active)
                item.ShowAllTiles();
        }
    }

    private int GetActiveChunkIndex()
    {
        return (int)(player.position.x / sqrtChunkLegth * mapSettings.tileSideLength) * chunksWidthCount + (int)(player.position.z / sqrtChunkLegth * mapSettings.tileSideLength);
    }
    private MapChunk GetActiveChunk()
    {
        return mapChunks[GetActiveChunkIndex()];
    }
    private List<MapChunk> GetChunkNeighbours(int chunkIndex)
    {
        List<MapChunk> neighbours = new List<MapChunk>();

        int[] neighbourIndexes =
        {
            chunkIndex - 1 - chunksWidthCount,
            chunkIndex - chunksWidthCount,
            chunkIndex + 1 - chunksWidthCount,

            chunkIndex - 1,
            chunkIndex + 1,

            chunkIndex - 1 + chunksWidthCount,
            chunkIndex + chunksWidthCount,
            chunkIndex + 1 + chunksWidthCount,
        };

        foreach (int index in neighbourIndexes)
        {
            if (index > 0 && index < mapChunks.Count)
                neighbours.Add(mapChunks[index]);
        }

        return neighbours;
    }
    private List<MapChunk> GetChunkNeighbours(MapChunk chunk)
    {
        List<MapChunk> neighbours = new List<MapChunk>();
        int[] neighbourIndexes =
        {
            chunk.chunkIndex - 1 - chunksWidthCount,
            chunk.chunkIndex - chunksWidthCount,
            chunk.chunkIndex + 1 - chunksWidthCount,

            chunk.chunkIndex - 1,
            chunk.chunkIndex + 1,

            chunk.chunkIndex - 1 + chunksWidthCount,
            chunk.chunkIndex + chunksWidthCount,
            chunk.chunkIndex + 1 + chunksWidthCount,
        };

        foreach (int index in neighbourIndexes)
        {
            if (index > 0 && index < mapChunks.Count)
                neighbours.Add(mapChunks[index]);
        }

        return neighbours;
    }
}
