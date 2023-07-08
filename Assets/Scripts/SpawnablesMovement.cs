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
        ref bool nextSpawnCallable = ref gameObject.GetComponentInParent<SpawnableBehaviour>().isCallable;
        if (-1f < transform.position.y && transform.position.y < 0f)
        {
            gameObject.GetComponentInParent<SpawnableBehaviour>().SpawnObjects();
            nextSpawnCallable = false;
        }
        if (transform.position.y < -6f)
        {
            if (!nextSpawnCallable) nextSpawnCallable = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I am : " + gameObject.name);
    }

}
