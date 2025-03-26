using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public Dialog gameoverDialogl;
    public Text mainCoinTxt;
    public Text gamePlayCoinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowGameGUI(bool isShow)
    {
        if(gameGUI)
            gameGUI.SetActive(isShow);

        if(homeGUI)
            homeGUI.SetActive(!isShow);
    }

    public void UpdateMainCoins()
    {
        if(mainCoinTxt)
            mainCoinTxt.text = Pref.coins.ToString();

        if(gamePlayCoinText)
            gamePlayCoinText.text = Pref.coins.ToString();
    }
}
