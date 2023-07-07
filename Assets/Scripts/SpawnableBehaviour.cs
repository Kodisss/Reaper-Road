using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableBehaviour : MonoBehaviour
{
    public Vector3[] spawn_positions = new Vector3[]
    {
        new Vector3(-5f, 5.5f, -1f),
        new Vector3( 0f, 5.5f, -1f),
        new Vector3( 5f, 5.5f, -1f)
     };

    public GameObject[] spawnables;

    public float spawnInterval = 1f; // Time interval between each spawn
    public float moveSpeed = 5f;     // Speed at which the object moves downward
    public float despawnDelay = 3f;  // Time delay before despawning the object

    private float timer;             // Timer to track spawn interval
    private GameObject spawnedObject; // Reference to the spawned object

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }


    void SpawnObjects()
    {
        for(int i = 0; i < spawn_positions.Length; ++i)
        {
            if (Random.value > 0.7)
                spawnedObject = Instantiate(spawnables[1], spawn_positions[i], Quaternion.identity);
            else
                spawnedObject = Instantiate(spawnables[0], spawn_positions[i], Quaternion.identity);
        }
    }


}
