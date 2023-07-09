using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnableBehaviour : MonoBehaviour
{
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(-14.8f, 39.4f, 0f),
        new Vector3( 0f, 39.4f, 0f),
        new Vector3( 14.8f, 39.4f, 0f)
     };

    [SerializeField] private GameObject[] passTiles;
    [SerializeField] private GameObject[] emptyTiles;
    [SerializeField] private GameObject[] obstacleTiles;
    [SerializeField] private float acceleration = 1f;

    private enum PassTilesNames {Soul, Boost};

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
            WhichPassTiles(positionOfPass);

            for (int i = 0; i < spawnPositions.Length; ++i)
            {
                if (i != positionOfPass) SpawnRandomTile(i, emptyTiles);
            }
        }
    }

    private void WhichPassTiles(int position)
    {
        float value = Random.value;
        if (value < 0.8f)
        {
            SpawnRandomTile(position, obstacleTiles);
        }
        else if (value > 0.8f && value < 0.95f)
        {
            Instantiate(passTiles[(int)PassTilesNames.Soul], spawnPositions[position], Quaternion.identity, transform);
        }
        else
        {
            Instantiate(passTiles[(int)PassTilesNames.Boost], spawnPositions[position], Quaternion.identity, transform);
        }
    }

    private void SpawnRandomTile(int position, GameObject[] tab)
    {
        int typeOfTile = Random.Range(0, tab.Length);
        Instantiate(tab[typeOfTile], spawnPositions[position], Quaternion.identity, transform);
    }

    public float GetAcceleration()
    {
        return acceleration;
    }
}
