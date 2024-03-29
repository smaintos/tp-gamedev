using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject[] coinPrefabs;
    public float spawnTime = 2f;
    public float speed = 7f;

    private float timeUntilSpawn;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
        else
        {
            DestroyAllSpawnedObjects();
        }
    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= spawnTime)
        {
            Spawn();
            timeUntilSpawn = 0f;
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, 3);

        if (randomIndex == 0 || randomIndex == 1)
        {
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
            Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * speed;

            spawnedObjects.Add(spawnedObstacle);
        }
        else if (randomIndex == 2)
        {
            GameObject coinToSpawn = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
            GameObject spawnedCoin = Instantiate(coinToSpawn, transform.position, Quaternion.identity);
            Rigidbody2D coinRB = spawnedCoin.GetComponent<Rigidbody2D>();
            coinRB.velocity = Vector2.left * speed;

            spawnedObjects.Add(spawnedCoin);
        }
    }

    private void DestroyAllSpawnedObjects()
    {
        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }

        spawnedObjects.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            HandleCoinCollision(other.gameObject);
        }
    }

    private void HandleCoinCollision(GameObject coin)
    {
        GameManager.Instance.currentScore += 10;
        coin.SetActive(false);
    }
}