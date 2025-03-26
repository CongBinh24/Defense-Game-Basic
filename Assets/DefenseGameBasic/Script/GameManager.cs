using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IComponentChecking
{
    public float spawnTime;
    public Enemy[] enemyPrefabs;
    private bool m_isGameOver;
    private int m_score;

    public GUIManager guiMng;
    public int Score { get => m_score; set => m_score = value; }

    void Start()
    {
        if(IsComponentsNull()) return;
        guiMng.ShowGameGUI(false);
        guiMng.UpdateMainCoins();
    }

    public void PlayGame()
    {
        StartCoroutine(SpawnEnemy());
        guiMng.ShowGameGUI(true);
        guiMng.UpdateGamePlayCoins();
    }
    public bool IsComponentsNull()
    {
        return guiMng == null; 
    }

    public void GameOver()
    {
        if(m_isGameOver) return;

        m_isGameOver = true;
        Pref.bestScore = m_score;

        if(guiMng.gameoverDialog)
            guiMng.gameoverDialog.Show(true);
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
