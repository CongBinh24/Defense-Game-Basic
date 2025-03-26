using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public Text priceTxt;
    public Image hud;
    public Button btn;
    public void UpdateUI(ShopItem item, int itemIdx)
    {
        if(item == null) return;

        if(hud)
            hud.sprite = item.previewImg;

        bool isUnclocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);

        if (isUnclocked)
        {
            if (Pref.curPlayerId == itemIdx)
            {
                if (priceTxt)
                    priceTxt.text = "Active";
                else if (priceTxt) 
                    priceTxt.text = "owned";
            }
        }
        else
        {
            if(priceTxt)
                priceTxt.text = item.price.ToString();
        }
    }
}
