using UnityEngine;

public class treeSpawner : MonoBehaviour
{
    public GameObject treePrefab;  // Assign the tree prefab in the Unity Inspector
    public int numberOfTrees = 100;  // Number of trees you want to spawn
    public float spawnAreaWidth = 50f;  // Width of the spawn area
    public float spawnAreaDepth = 50f;  // Depth of the spawn area
    public Vector3 spawnAreaCenter;  // Center of the spawn area
    public float yOffset = 0f;  // Vertical offset for spawned trees

    void Start()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            // Generate random x and z coordinates within the spawn area
            float x = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2) + spawnAreaCenter.x;
            float z = Random.Range(-spawnAreaDepth / 2, spawnAreaDepth / 2) + spawnAreaCenter.z;

            // Create the position Vector3
            Vector3 spawnPosition = new Vector3(x, spawnAreaCenter.y + yOffset, z);

            // Instantiate the tree prefab at the random position
           GameObject tree = Instantiate(treePrefab, spawnPosition, Quaternion.identity);
			// Randomly rotate tree around the Y-axis
            float randomYRotation = Random.Range(0, 360);
            tree.transform.eulerAngles = new Vector3(0, randomYRotation, 0);
        }
    }
}
 