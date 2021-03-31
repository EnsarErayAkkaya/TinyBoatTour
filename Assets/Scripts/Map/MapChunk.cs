using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapChunk
{
    public IEnumerable<Tile> tiles;
    public Vector3 center;
    public bool active;
    public MapChunk(IEnumerable<Tile> tiles, Vector3 center)
    {
        this.tiles = tiles;
        this.center = center;
        active = false;
        DeactiveAllTiles();
    }
    public void ActiveAllTiles()
    {
        foreach (Tile tile in tiles)
        {
            tile.gameObject.SetActive(true);
        }
    }
    public void DeactiveAllTiles()
    {
        foreach (Tile tile in tiles)
        {
            tile.gameObject.SetActive(false);
        }
    }
}
