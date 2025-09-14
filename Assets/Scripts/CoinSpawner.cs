using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject coinPrefab;
    public float timeBetweenWaves = 2f;

    public Transform left_pos;
    public Transform right_pos;
    public Transform center_pos;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + timeBetweenWaves;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + timeBetweenWaves;
        }
    }

    void SpawnCoin()
    {
        float spawnX;
        int randomIndex = Random.Range(0, 3); // Randomly select left, right, or center

        switch (randomIndex)
        {
            case 0:
                spawnX = left_pos.position.x;
                break;
            case 1:
                spawnX = left_pos.position.x;
                break;
            default:
                spawnX = center_pos.position.x;
                break;
        }

        Vector3 coinPosition = new Vector3(spawnX, spawnPos.position.y, spawnPos.position.z);

        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }
}
