using UnityEngine;
public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array to hold your prefabs
    public Vector3 spawnAreaMin;       // Minimum coordinates for random spawn position
    public Vector3 spawnAreaMax;       // Maximum coordinates for random spawn position

    void Start()
    {
        // Example: Spawn a random object every 2 seconds after a 1-second delay
        InvokeRepeating("SpawnRandomObject", 1f, 2f);
    }

    void SpawnRandomObject()
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("No objects assigned to spawn!");
            return;
        }

        // Choose a random object from the array
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject selectedObject = objectsToSpawn[randomIndex];

        // Generate a random spawn position within the defined area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Instantiate the selected object at the random position
        Instantiate(selectedObject, spawnPosition, Quaternion.identity);
    }
}
