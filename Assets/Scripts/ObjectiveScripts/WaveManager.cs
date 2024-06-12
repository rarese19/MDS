using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int totalWaves = 10;
    private int currentWave = 0;
    private List<GameObject> currentEnemies = new List<GameObject>();
    private ObjectiveManager objectiveManager;

    public GameObject enemyPrefab;  // Reference to the enemy Prefab
    public Transform[] spawnPoints; // Array of spawn points
    public Path[] paths;

    void Start()
    {
        objectiveManager = GameObject.FindObjectOfType<ObjectiveManager>();
    }

    private void Iniciate()
    {
        if (currentWave == 0)
        {
            objectiveManager.description.text += "\nWave: 1";
            StartCoroutine(StartWaves());
        }
    }

    IEnumerator StartWaves()
    {
        while (currentWave < totalWaves)
        {
            currentWave++;
            Debug.Log("wave: " + currentWave);
            SpawnWave();
            // Wait until all enemies are dead before starting the next wave
            yield return new WaitUntil(() => currentEnemies.Count == 1);
        }
        objectiveManager.CompleteObjective();
    }

    void SpawnWave()
    {
        int numberOfEnemies = currentWave * 5; // Example: Increase the number of enemies per wave

        int descriptionLength = objectiveManager.description.text.Length;
        objectiveManager.description.text = objectiveManager.description.text.Substring(0, descriptionLength - 1) + currentWave.ToString();

        Debug.Log(objectiveManager.description.text);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int rand = Random.Range(0, spawnPoints.Length);

            // Randomly select a spawn point
            Transform spawnPoint = spawnPoints[rand];

            // Instantiate enemy at the spawn point's position and rotation
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            currentEnemies.Add(enemy);

            // Ensure enemies notify when they are destroyed
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.OnDestroyed += HandleEnemyDestroyed;
            }

            // Assign a random path to the enemy's EnemyAI component
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                Path randomPath = paths[rand];
                enemyAI.path = randomPath;
            }
        }

        Debug.Log("Wave " + currentWave + " spawned with " + numberOfEnemies + " enemies.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectiveManager.getCurrentObjective() == "Survive")
            {
                Iniciate();
            }
        }
    }

    void HandleEnemyDestroyed()
    {
        // Find the enemy that was destroyed in the list and remove i

        for (int i = currentEnemies.Count - 1; i >= 0; i--)
        {
            if (currentEnemies[i] == null)  // Enemy is destroyed, so it's null
            {
                currentEnemies.RemoveAt(i);
            }
        }
        Debug.Log(currentEnemies.Count);
        
    }
}
