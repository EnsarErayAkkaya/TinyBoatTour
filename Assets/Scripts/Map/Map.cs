using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public MapSettings mapSettings;
    public List<MapChunk> mapChunks;

    public Transform player;

    private MapGenerator mapGenerator;
    private MapChunksGenerator mapChunksGenerator;

    private float chunkActivateDistance;

    private void Start()
    {
        PRNG prng = new PRNG(mapSettings.seed);
        mapGenerator = new MapGenerator(mapSettings);
        mapChunksGenerator = new MapChunksGenerator(mapSettings);

        chunkActivateDistance = (mapSettings.tileSideLength * Mathf.Sqrt(mapSettings.chunkLength)) * 3 / 2;

        mapChunks = mapChunksGenerator.GenerateMapChunks(mapGenerator.GenerateMap());
    }
    private void Update()
    {
        foreach (MapChunk chunk in mapChunks)
        {
            if(Vector3.Distance(player.position,chunk.center) <= chunkActivateDistance)
            {
                chunk.active = true;
                chunk.ActiveAllTiles();
            }
            else
            {
                chunk.active = false;
                chunk.DeactiveAllTiles();
            }
        }
    }
}
