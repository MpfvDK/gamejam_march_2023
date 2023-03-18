using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bounds : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y <= -5)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
