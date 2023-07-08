using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class SpawnablesMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpawnableBehaviour spawnableBehaviour;

    private float verticalSpeed = 2.0f;
    private float horizontalSpeed = 3.0f;

    private float acceleration = 1f;

    private Vector2 movement;
    private bool canMove = true;
    private bool canSpawn = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnableBehaviour = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableBehaviour>();
        GameManager.instance.endGame += EndSpawn;
    }

    // Update is called once per frame
    private void Update()
    {
        acceleration = spawnableBehaviour.GetAcceleration();

        if (movement.x != 0 && canMove && AmIInTheMiddle()) StartCoroutine(Move());

        rb.velocity = verticalSpeed * acceleration * Vector2.down;

        CheckPosition();
    }

    private void CheckPosition()
    {
        if (transform.position.y < -6f)
        {
            canSpawn = true;
            Destroy(gameObject);
        }  
    }

    private bool AmIInTheMiddle()
    {
        if(transform.position.y < 2 && transform.position.y > -2) return true;
        else return false;
    }

    private void EndSpawn()
    {
        GameManager.instance.isPlaying = false;
        Debug.Log("Game Over");
        GameManager.instance.endGame -= EndSpawn;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Debug.Log("I am : " + gameObject.name);
        if (collision.CompareTag("MiddleLine") && gameObject.CompareTag("Pass"))
        {
            if (canSpawn) spawnableBehaviour.SpawnObjects();
            canSpawn = false;
        }

        if (gameObject.CompareTag("Obstacle") && collision.CompareTag("Player"))
        {
            EndSpawn();
        }
    }

    private void OnMovements(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private IEnumerator Move()
    {
        canMove = false;

        Vector3 startPosition = transform.position;

        float elapsedTime = 0f;

        Vector3 targetPosition;
        float targetPositionIndex;

        if (movement.x > 0)
        {
            targetPositionIndex = transform.position.x + 5;
        }
        else
        {
            targetPositionIndex = transform.position.x - 5;
        }

        if (targetPositionIndex > 5)
        {
            targetPositionIndex = -5;
        }
        else if(targetPositionIndex < -5)
        {
            targetPositionIndex = 5;
        }

        float startpositionfloat = transform.position.y;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * horizontalSpeed * acceleration;

            targetPosition = new Vector3(targetPositionIndex, startpositionfloat - verticalSpeed * elapsedTime / horizontalSpeed, transform.position.z);

            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);

            yield return null;
        }

        //transform.position = targetPosition;

        canMove = true;
    }
}
