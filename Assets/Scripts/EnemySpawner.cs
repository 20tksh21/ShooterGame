using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private float spawnInterval = 1.5f;
    private float timer;

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
        float randomY = Random.Range(-4f, 4f);
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);        //Quaternion.identity→そのままの向き、回転ゼロ
    }
}
