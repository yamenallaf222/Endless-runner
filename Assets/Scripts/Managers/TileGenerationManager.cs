using System.Collections.Generic;
using UnityEngine;

public class TileGenerationManager : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    GameObject obstaclePrefab;

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

        GameObject[] obstacles = new GameObject[obstacleCount];

        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 obstaclePosition = tile.transform.position;

            obstaclePosition.x += Random.Range(-5, 5);
            obstaclePosition.z += Random.Range(-5, 5);

            GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);

            obstacles[i] = obstacle;
        }

        obstaclesTilesMapped.Add(tile, obstacles);
    }
}
