using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnableBehaviour : MonoBehaviour
{
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(-5f, 5.5f, -1f),
        new Vector3( 0f, 5.5f, -1f),
        new Vector3( 5f, 5.5f, -1f)
     };

    [SerializeField] private GameObject[] passTiles;
    [SerializeField] private GameObject[] obstacleTiles;

    private enum PassTilesNames {Empty, Soul, Boost};

    [SerializeField] private float spawnInterval = 1f; // Time interval between each spawn
    [SerializeField] private float moveSpeed = 5f;     // Speed at which the object moves downward
    [SerializeField] private float despawnDelay = 3f;  // Time delay before despawning the object

    private int numberOfObstacles;

    private int numberOfRoads;


    // Start is called before the first frame update
    void Start()
    {
        numberOfObstacles = obstacleTiles.Length;
        numberOfRoads = spawnPositions.Length;
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        int positionOfPass = Random.Range(0, numberOfRoads);
        PassTilesNames typeOfPassTiles = WhichPassTiles();

        Debug.Log("PassTiles = " + (int)typeOfPassTiles + " position = " + positionOfPass);

        Instantiate(passTiles[(int)typeOfPassTiles], spawnPositions[positionOfPass], Quaternion.identity);

        for(int i = 0; i < spawnPositions.Length; ++i)
        {
            if (i != positionOfPass) SpawnRandomTile(i);
        }
    }

    private PassTilesNames WhichPassTiles()
    {
        float value = Random.value;
        if (value < 0.6f)
        {
            return PassTilesNames.Empty;
        }
        else if (value > 0.6f && value < 0.8f)
        {
            return PassTilesNames.Soul;
        }
        else
        {
            return PassTilesNames.Boost;
        }
    }

    private void SpawnRandomTile(int position)
    {
        int typeOfObstacle = Random.Range(0, numberOfObstacles);
        Instantiate(obstacleTiles[typeOfObstacle], spawnPositions[position], Quaternion.identity);
    }
}
