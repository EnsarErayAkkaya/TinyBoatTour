using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator
{
    private static System.Type[] tileTypes = { typeof(Tile), typeof(MeshFilter), typeof(MeshRenderer) };
    public static Tile CreateTile(Vector3 pos, TileSetting ts, float sideLength)
    {
        Vector3 centeredPos = pos + new Vector3(sideLength / 2, 0, sideLength / 2);

        Tile t = new GameObject("Tile[" + centeredPos.x + "," + centeredPos.y + "," + centeredPos.z + "]", tileTypes).GetComponent<Tile>();
        
        t.transform.position = centeredPos;

        MeshFilter meshFilter= t.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices =
        {
            new Vector3(-sideLength / 2, 0, -sideLength / 2),
            new Vector3(sideLength / 2, 0, -sideLength / 2),
            new Vector3(-sideLength / 2, 0, sideLength / 2),
            new Vector3(sideLength / 2, 0, sideLength / 2),
        };

        int[] triangles =
        {
            2,1,0,
            2,3,1
        };

        Vector2[] uvs = {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        t.GetComponent<MeshRenderer>().sharedMaterial = ts.material;
        return t;
    }
}
