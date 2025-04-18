using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverDialog : Dialog
{
    public Text bestscoreText;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        if(bestscoreText)
        bestscoreText.text = Pref.bestScore.ToString("0000");
    }

    public void Replay()
    {
        Close();
        SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
