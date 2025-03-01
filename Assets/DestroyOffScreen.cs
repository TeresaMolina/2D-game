using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float minY = -6f; // Adjust based on your game

    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject); // Remove bomb if it falls too low
        }
    }
}

