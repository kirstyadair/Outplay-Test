using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    [Header("X Values")]
    public float maxXPosition;
    public float minXPosition;
    [Header("Y Values")]
    public float maxYPosition;
    public float minYPosition;
    [Header("Z Values")]
    public float maxZPosition;
    public float minZPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Parent gameObject to keep hierarchy tidy
        GameObject parent = new GameObject();
        parent.name = "Parent";

        // Instantiate 100 gameObjects in random positions
        for (int i = 0; i < 100; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, ChooseRandomPosition(), Quaternion.identity);
            newObject.transform.SetParent(parent.transform);
        }
    }

    // Generate a random Vector3
    Vector3 ChooseRandomPosition()
    {
        Vector3 randomPos = new Vector3(Random.Range(minXPosition, maxXPosition), Random.Range(minYPosition, maxYPosition), Random.Range(minZPosition, maxZPosition));
        return randomPos;
    }
}
