using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile : MonoBehaviour
{
    public bool active;

    public void ShowTile()
    {
        StartCoroutine(Rise());
    }
    public void HideTile()
    {
        //StartCoroutine(Fall());
        gameObject.SetActive(false);
    }
    private IEnumerator Rise()
    {
        active = true;
        float t = 0;
        Vector3 open = new Vector3(transform.position.x, 0, transform.position.z);
        while (t <= 1)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, open, t);
            yield return null;
        }
    }
    private IEnumerator Fall()
    {
        float t = 0;
        active = false;
        Vector3 closed = new Vector3(transform.position.x, -1, transform.position.z);
        while (t <= 1)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, closed, t);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
