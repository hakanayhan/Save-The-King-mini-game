using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D collider2d;

    private void Awake()
    {
        Initialize();
    }


    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<CircleCollider2D>();
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetRadius(float r)
    {
        collider2d.radius = r;
    }

}
