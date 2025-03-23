using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float spawnTime;
    public Enemy[] enemyPrefabs;
    private bool m_isGameOver;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (!m_isGameOver)
        {
            if (enemyPrefabs != null && enemyPrefabs.Length > 0)
            {
                int randIdx = Random.Range(0, enemyPrefabs.Length);

                Enemy enemyPrefab = enemyPrefabs[randIdx];

                if (enemyPrefab)
                {
                    Instantiate(enemyPrefab, new Vector3 (8,0,0) , Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
