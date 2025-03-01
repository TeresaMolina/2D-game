using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject batteryspawn;
    public float spawnRate = 5f;
    public float minX = -7f, maxX = 7f; 

    void Start()
    {
        InvokeRepeating("SpawnBattery", 2f, spawnRate); // Start spawning
    }

    void SpawnBattery()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);
        Instantiate(batteryspawn, spawnPos, Quaternion.identity);
    }
}
