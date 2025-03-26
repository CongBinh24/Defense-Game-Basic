using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text titleText;
    public Text contentTxt;

    public virtual void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    public virtual void UpdateDialog(string title, string content)
    {
        if (titleText)
            titleText.text = title;

        if(contentTxt) 
            contentTxt.text = content;   
    }

    public virtual void UpdateDialog() { }

    public virtual void Close() 
    {
        gameObject.SetActive(false);
    }


}
