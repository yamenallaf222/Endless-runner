using System.Collections.Generic;
using UnityEngine;

public class PlayerTileTriggerIntersectionChecker : MonoBehaviour
{
    [SerializeField]
    TileGenerationManager tileGenerationManager = null;

    public ScoreUI scoreUI = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InstantiationTrigger"))
        {
            // Logic to handle player entering a tile trigger
            Debug.Log("Player entered tile trigger: " + other.name);

            tileGenerationManager?.generateNewTile(other.transform.parent.position);
            scoreUI?.incrementScore();
        }
        else if (other.CompareTag("DestroyTrigger"))
        {
            // Logic to handle player entering a destroy trigger
            Debug.Log("Player entered destroy trigger: " + other.name);
            GameObject tile = other.transform.parent.gameObject;
            Destroy(tile);

            GameObject[] obstaclesToRemove = tileGenerationManager.obstaclesTilesMapped.GetValueOrDefault(tile);

            for (int i = 0; i < obstaclesToRemove.Length; i++)
            {
                Destroy(obstaclesToRemove[i]);
            }
        }

    }
}
