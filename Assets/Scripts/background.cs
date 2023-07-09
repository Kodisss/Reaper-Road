using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Rigidbody2D rb;
    private float acceleration;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = 3.0f * Vector2.down;
    }

    private void Update()
    {
        if (transform.position.y < -40f) Destroy(gameObject);
    }
}
