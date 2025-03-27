using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IComponentChecking
{
    public float spawnTime;
    public Enemy[] enemyPrefabs;
    private bool m_isGameOver;
    private int m_score;
    private Player m_curPlayer;
    public ShopManager shopMng;
    public GUIManager guiMng;

    public AudioController auCtr;
    public int Score { get => m_score; set => m_score = value; }

    void Start()
    {
        if(IsComponentsNull()) return;
        guiMng.ShowGameGUI(false);
        guiMng.UpdateMainCoins();
    }

    public bool IsComponentsNull()
    {
        return guiMng == null || shopMng == null || auCtr == null;
    }

    public void PlayGame()
    {
        if (IsComponentsNull()) return;

        ActivePlayer();

        StartCoroutine(SpawnEnemy());
        guiMng.ShowGameGUI(true);
        guiMng.UpdateGamePlayCoins();

        auCtr.PlayBgm(); 
    }

    public void ActivePlayer()
    {
        if (m_curPlayer)
            Destroy(m_curPlayer.gameObject);

        var shopItems = shopMng.items;

        if (shopItems == null || shopItems.Length <= 0) return;

        var newPlayerPb = shopItems[Pref.curPlayerId].playerPrefab;

        if(newPlayerPb)
            m_curPlayer = Instantiate(newPlayerPb, new Vector3 (-7f,-1f,0),Quaternion.identity);  
    }
    public void GameOver()
    {
        if(m_isGameOver) return;

        m_isGameOver = true;
        Pref.bestScore = m_score;

        if(guiMng.gameoverDialog)
            guiMng.gameoverDialog.Show(true);

        auCtr.PlaySound(auCtr.gameover);
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
