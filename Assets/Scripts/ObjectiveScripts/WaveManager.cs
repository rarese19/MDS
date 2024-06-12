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
            SpawnWave();
            // Wait until all enemies are dead before starting the next wave
            yield return new WaitUntil(() => currentEnemies.Count == 0);
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
            // Randomly select a spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate enemy at the spawn point's position and rotation
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            currentEnemies.Add(enemy);

            // Ensure enemies notify when they are destroyed
            //enemy.GetComponent<Enemy>().OnDestroyed += HandleEnemyDestroyed;
        }
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
}
