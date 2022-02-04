using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    Vector3 spawnPos = Vector3.zero;
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine(){
        // spawnPos.x = this.transform.position.x + Random.Range(-9f, 9f);
        // spawnPos.y = this.transform.position.y;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 20.0f));

            Instantiate(EnemyPrefab, this.transform.position, Quaternion.identity);
        }

    }
}
