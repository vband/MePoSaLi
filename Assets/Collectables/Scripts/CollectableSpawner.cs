using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] collectablePrefabs;
    [SerializeField]
    private float spawnTimeIntervalInSeconds = 3f;

    private void Start()
    {
        StartCoroutine(SpawnCollectable());
    }

    private IEnumerator SpawnCollectable()
    {
        while(true)
        {
            Transform collectable = collectablePrefabs[Random.Range(0, collectablePrefabs.Length)];
            Instantiate(collectable, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTimeIntervalInSeconds);
        }
    }
}
