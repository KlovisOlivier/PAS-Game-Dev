using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Pengaturan Spawner")]
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;

    [Header("Lokasi Spawn")]
    // Array untuk menyimpan banyak titik lokasi spawn
    public Transform[] spawnPoints; 

    private GameObject currentEnemy;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => currentEnemy == null);

            yield return new WaitForSeconds(spawnInterval);

            if (enemyPrefab == null)
            {
                Debug.LogWarning("Prefab musuh belum dimasukkan ke spawner!");
            }

            Vector3 spawnPosition = transform.position;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                spawnPosition = spawnPoints[randomIndex].position;
            }

            currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}