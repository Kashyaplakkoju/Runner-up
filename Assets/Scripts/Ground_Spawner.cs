using System.Collections;
using UnityEngine;

public class Ground_Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject groundPrefab;
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;

    public Transform center_pos;
    public Transform left_pos;
    public Transform right_pos;

    public static Ground_Spawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SpawnGround();
    }

    public void SpawnGround()
    {
        GameObject ground = Instantiate(groundPrefab, spawnPos.position, Quaternion.identity);
        spawnPos.position += Vector3.forward * 20f; // Move spawnPos forward
        SpawnObstacle(ground.transform.position);
    }

    public void SpawnObstacle(Vector3 groundPosition)
    {
        // Randomly select an obstacle to spawn
        GameObject obstacleToSpawn = Random.value > 0.5f ? obstaclePrefab1 : obstaclePrefab2;

        Vector3 obstaclePosition;
        float randomValue = Random.value;

        if (randomValue < 0.25f) // 25% chance to spawn on the left
        {
            obstaclePosition = new Vector3(left_pos.position.x, left_pos.position.y, left_pos.position.z);
        }
        else if (randomValue < 0.5f) // 25% chance to spawn on the right
        {
            obstaclePosition = new Vector3(right_pos.position.x, right_pos.position.y, right_pos.position.z);
        }
        else // 50% chance to spawn in the center
        {
            obstaclePosition = new Vector3(center_pos.position.x, left_pos.position.y, left_pos.position.z);
        }

        obstaclePosition += groundPosition; // Add ground position to obstacle position

        Instantiate(obstacleToSpawn, obstaclePosition, Quaternion.identity);
    }
}
