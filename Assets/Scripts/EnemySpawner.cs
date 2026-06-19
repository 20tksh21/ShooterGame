using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
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

        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = spawnedEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.SetHp(spawnCount);
        }

    }
}
