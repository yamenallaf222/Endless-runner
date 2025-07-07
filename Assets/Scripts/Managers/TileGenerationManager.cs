using System.Collections.Generic;
using UnityEngine;

public class TileGenerationManager : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    GameObject obstaclePrefab;

    public float obstacleBoundsPadding = 0.5f;
    public int minimumObstacleCount = 1;
    public int maximumObstacleCount = 6;

    public Dictionary<GameObject, GameObject[]> obstaclesTilesMapped;

    void Start()
    {
        obstaclesTilesMapped = new Dictionary<GameObject, GameObject[]>();
    }

    public bool generateNewTile(Vector3 position)
    {
        // Logic to generate a new tile at the specified position
        Debug.Log("Generating new tile at position: " + position);

        if (tilePrefab == null)
        {
            Debug.LogError("Tile prefab is not assigned.");
            return false;
        }

        generateCompleteTile(position);

        // Here you would typically instantiate a new tile prefab and set its position
        return true;
        // GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);
    }

    private void generateCompleteTile(Vector3 position)
    {
        GameObject tile = Instantiate(tilePrefab, position + Vector3.forward * 10f, tilePrefab.transform.rotation);

        int obstacleCount = Random.Range(minimumObstacleCount, maximumObstacleCount);

        // Calculate the bounds of the tile to place obstacles within it
        Bounds bounds = tile.transform.GetChild(2).GetComponent<BoxCollider>().bounds;


        GameObject[] obstacles = new GameObject[obstacleCount];

        for (int i = 0; i < obstacleCount; i++)
        {

            Vector3 randomPos = new Vector3(
                Random.Range(bounds.min.x + obstacleBoundsPadding, bounds.max.x - obstacleBoundsPadding),
                tile.transform.position.y,
                Random.Range(bounds.min.z + obstacleBoundsPadding, bounds.max.z - obstacleBoundsPadding)
            );
            GameObject obstacle = Instantiate(obstaclePrefab, randomPos, Quaternion.identity);

            obstacles[i] = obstacle;
        }

        obstaclesTilesMapped.Add(tile, obstacles);
    }
}
