using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinText : MonoBehaviour
{
    public int coins = 0;
    public TMPro.TextMeshProUGUI text;

    public void addCoin()
    {
        coins++;
        text.text = "Coins: " + coins.ToString();
    }
    private void FixedUpdate()
    {
        text.text = "Coins: "+coins.ToString();
    }
}
