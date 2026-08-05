using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public float spawnInterval = 1.5f;
    public float spawnDistance = 20f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        // 3 fixed lanes on X-axis
        float[] lanes = { -6f, 0f, 6f };
        float laneX = lanes[Random.Range(0, lanes.Length)];

        Vector3 spawnPos = new Vector3(
            laneX,
            0.5f,
            spawnDistance
        );

        Instantiate(
            obstaclePrefabs[randomIndex],
            spawnPos,
            Quaternion.identity
        );
    }
}