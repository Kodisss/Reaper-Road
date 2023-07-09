using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetection : MonoBehaviour
{
    private SpawnableBehaviour spawnableBehaviour;

    // Start is called before the first frame update
    private void Start()
    {
        spawnableBehaviour = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnLine"))
        {
            //Debug.Log("I triggered child");
            spawnableBehaviour.SpawnObjects();
        }
    }
}
