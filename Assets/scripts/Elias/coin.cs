using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int coins = 0;
    public coinText coinText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinText.addCoin();
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
