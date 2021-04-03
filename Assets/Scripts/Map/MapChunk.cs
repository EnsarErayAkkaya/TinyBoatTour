using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapChunk
{
    public int chunkIndex;
    public IEnumerable<Tile> tiles;
    public Vector3 center;
    public bool active;
    public MapChunk(IEnumerable<Tile> tiles, Vector3 center, int index)
    {
        this.tiles = tiles;
        this.center = center;
        this.chunkIndex = index;
        active = false;
    }
    public void ShowTilesInScreen(Camera cam)
    {
        foreach (Tile tile in tiles)
        {
            CheckInScreen(tile, cam);
        }
    }
    public void ShowAllTiles()
    {
        active = true;
        foreach (Tile tile in tiles)
        {
            if (!tile.gameObject.activeSelf)
                tile.gameObject.SetActive(true);
        }
    }

    public void HideAllTiles()
    {
        active = false;
        foreach (Tile tile in tiles)
        {
            if(tile.gameObject.activeSelf)
                tile.HideTile();
        }
    }

    public void CheckInScreen(Tile tile, Camera cam)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(new Vector3(tile.transform.position.x,0,tile.transform.position.z));
        if (viewPos.x > -0.1f && viewPos.x <= 1.1f && viewPos.y > -0.1f && viewPos.y <= 1.1f)
        {
            if (!tile.gameObject.activeSelf)
            {
                tile.gameObject.SetActive(true);
                //tile.ShowTile();
            }
        }
        else
        {
            if (tile.gameObject.activeSelf)
                tile.HideTile();
        }
    }

}
