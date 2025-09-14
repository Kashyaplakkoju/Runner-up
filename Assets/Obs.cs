using System.Collections;
using UnityEngine;

public class Obs : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPos;
    public float timeToSpawn;
    public float timeBetweenWave;

    public static Obs instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Set the initial time to spawn
        timeToSpawn = Time.time + timeBetweenWave;
    }

    void Update()
    {
        if (Time.time > timeToSpawn)
        {
            SpawnObstacle();
            timeToSpawn = Time.time + timeBetweenWave; // Update the next spawn time
        }
    }

    public void SpawnObstacle()
    {
        float x = Random.Range(spawnPos.position.x - 10f, spawnPos.position.x + 10f);
        float z = Random.Range(spawnPos.position.z - 10f, spawnPos.position.z + 10f);
        Vector3 spawnPosition = new Vector3(x, spawnPos.position.y, z);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
