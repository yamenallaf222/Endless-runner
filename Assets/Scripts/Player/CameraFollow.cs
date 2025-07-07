using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign your player’s transform in the Inspector
    public Vector3 offset;   // Set this to control camera distance

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}