using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> spawnedEnemies;
    public GameObject enemyPrefab;
    public List<Vector3> spawnPoints;
    public int spawnTime;
    public int maxEnemyCount;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCorutine(spawnTime));
    }

    public IEnumerator SpawnCorutine(int spawnTime)
    {
        while (true)
        {
            GameObject instantiatedEnemy = SpawnEnemy();

            spawnedEnemies.Add(instantiatedEnemy);
            enemyCount++;

            if (enemyCount >= maxEnemyCount)
            {
                yield break;
            }

            yield return new WaitForSecondsRealtime(spawnTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject SpawnEnemy()
    {
        // take random position from spawnPoints List
        int indexOfEnemy = Random.Range(0, spawnPoints.Count);
        
        // instantiate newEnemy
        GameObject newEnemyObject = Instantiate(enemyPrefab, spawnPoints[indexOfEnemy], Quaternion.identity);
        Enemy enemy = newEnemyObject.GetComponent<Enemy>();
        // how to attach enemy to player ?
        enemy.player = GameObject.Find("Player");
        return newEnemyObject;
    }

    public void Awake()
    {
        spawnedEnemies = new List<GameObject>();
        enemyCount = 0;
    }
}
