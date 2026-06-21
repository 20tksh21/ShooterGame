using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    private float spawnInterval = 1.5f;
    private float timer;

    private int spawnCount = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        spawnCount++;

        float randomY = Random.Range(-4f, 4f);
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);

        Enemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        if (enemy != null)
        {
            enemy.SetHp(spawnCount);
        }

    }
}
