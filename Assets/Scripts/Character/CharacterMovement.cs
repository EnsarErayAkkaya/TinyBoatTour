using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;

    float x;
    float z;
    private Vector3 walkPos;
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 deltaPos = new Vector3(x, 0, z).normalized * speed * Time.deltaTime;

        animator.SetFloat("Speed", Mathf.Abs(deltaPos.magnitude));

        walkPos = transform.position + deltaPos;

        transform.LookAt(new Vector3(walkPos.x, 0, walkPos.z));
        transform.position = walkPos;
    }
}
