using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleHitDetector : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Player hit an obstacle: " + other.name);
            // Logic to handle player hitting an obstacle
            // For example, you might want to reduce the player's health or end the game
        }
    }
}
