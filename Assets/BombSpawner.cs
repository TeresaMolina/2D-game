using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab; 
    public float spawnRate = 2f;
    public float minX = -7f, maxX = 7f;

    void Start()
    {
        InvokeRepeating("SpawnBomb", 1f, spawnRate);
    }

    void SpawnBomb()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }
}
