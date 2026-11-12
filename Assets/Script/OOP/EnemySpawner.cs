using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Pengaturan Spawner")]
    public GameObject enemyPrefab; // Masukkan prefab musuh ke sini
    public float spawnInterval = 3f; // Waktu jeda antar spawn (dalam detik)

    [Header("Lokasi Spawn")]
    // Array untuk menyimpan banyak titik lokasi spawn
    public Transform[] spawnPoints; 

    void Start()
    {
        // Memulai proses generate musuh secara otomatis saat game berjalan
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        // Looping terus-menerus selama game berjalan
        while (true)
        {
            // Menunggu selama beberapa detik sesuai spawnInterval
            yield return new WaitForSeconds(spawnInterval);

            // Memanggil fungsi untuk memunculkan musuh
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Mencegah error jika prefab lupa dimasukkan
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Prefab musuh belum dimasukkan ke spawner!");
            return;
        }

        // Posisi default adalah posisi object spawner ini sendiri
        Vector3 spawnPosition = transform.position;

        // Jika kamu memasukkan titik spawn di Unity, pilih salah satu titik secara acak
        if (spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[randomIndex].position;
        }

        // Spawn musuh di lokasi yang sudah ditentukan
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}