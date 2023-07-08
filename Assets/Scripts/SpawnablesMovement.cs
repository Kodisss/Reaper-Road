using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnablesMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * Vector2.down;
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
