using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;    // The prefab of the enemy to spawn
    public Transform[] spawnPoints;   // Array of spawn points where enemies can spawn
    public float spawnRate = 2f;      // Time between enemy spawns
    public int maxEnemies = 5;        // Maximum number of enemies to spawn
    private int currentEnemies = 0;   // Current number of spawned enemies
    public float raycastLength = 10f; // Length of the raycast to find ground

    void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            // Check if we can spawn more enemies
            if (currentEnemies < maxEnemies)
            {
                // Get a random spawn point
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Raycast to find ground level
                RaycastHit2D hit = Physics2D.Raycast(randomSpawnPoint.position, Vector2.down, raycastLength);

                // Check if hit something that should be considered as ground (named "Tilemap")
                if (hit.collider != null && hit.collider.gameObject.name == "Tilemap")
                {
                    // Instantiate the enemy at the ground level
                    GameObject newEnemy = Instantiate(enemyPrefab, hit.point, Quaternion.identity);

                    // Increase the count of current enemies
                    currentEnemies++;
                }
                else
                {
                    Debug.LogWarning("No ground named 'Tilemap' found for enemy spawn at " + randomSpawnPoint.position);
                    // Debug log the position of the raycast hit
                    Debug.DrawRay(randomSpawnPoint.position, Vector2.down * raycastLength, Color.red, 1f);
                }

                // Wait for the spawn rate duration before spawning the next enemy
                yield return new WaitForSeconds(spawnRate);
            }
            else
            {
                // Wait for a short time before checking again
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void EnemyDefeated()
    {
        currentEnemies--;
    }

    // Optionally, you might want to add a method to increase maxEnemies or change spawn rate based on game progression
    public void IncreaseMaxEnemies(int amount)
    {
        maxEnemies += amount;
    }

    public void ChangeSpawnRate(float newSpawnRate)
    {
        spawnRate = newSpawnRate;
    }
}
