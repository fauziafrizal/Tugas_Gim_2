using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefab Enemy")]
    public GameObject enemyPrefab;

    [Header("Titik Spawn")]
    public Transform[] spawnPoints;

    [Header("Pengaturan Spawn")]
    public float delayAwal = 1f;
    public float intervalSpawn = 3f;
    public int maxEnemy = 5;

    private int jumlahEnemy = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", delayAwal, intervalSpawn);
    }

    void SpawnEnemy()
    {
        if (jumlahEnemy >= maxEnemy)
            return;

        if (spawnPoints.Length == 0 || enemyPrefab == null)
        {
            Debug.LogWarning("Spawner belum lengkap!");
            return;
        }

        int index = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPoints[index].position,
            Quaternion.identity
        );

        jumlahEnemy++;
    }
}