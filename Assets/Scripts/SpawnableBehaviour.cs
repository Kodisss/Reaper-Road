using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnableBehaviour : MonoBehaviour
{
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(-14.8f, 28.65f, 0f),
        new Vector3( 0f, 28.65f, 0f),
        new Vector3( 14.8f, 28.65f, 0f)
     };

    [SerializeField] private GameObject[] passTiles;
    [SerializeField] private GameObject[] obstacleTiles;
    [SerializeField] private float acceleration = 1f;

    private enum PassTilesNames {Empty, Soul, Boost};

    private int numberOfObstacles;

    private int numberOfRoads;

    // Start is called before the first frame update
    void Start()
    {
        numberOfObstacles = obstacleTiles.Length;
        numberOfRoads = spawnPositions.Length;
        SpawnObjects();
    }

    private void Update()
    {
        if (!GameManager.instance.isPlaying)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SpawnObjects()
    {
        if (GameManager.instance.isPlaying)
        {
            int positionOfPass = Random.Range(0, numberOfRoads);
            PassTilesNames typeOfPassTiles = WhichPassTiles();

            Instantiate(passTiles[(int)typeOfPassTiles], spawnPositions[positionOfPass], Quaternion.identity, transform);

            for (int i = 0; i < spawnPositions.Length; ++i)
            {
                if (i != positionOfPass) SpawnRandomTile(i);
            }
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
        Instantiate(obstacleTiles[typeOfObstacle], spawnPositions[position], Quaternion.identity, transform);
    }

    public float GetAcceleration()
    {
        return acceleration;
    }
}
