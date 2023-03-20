using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void startGame()
    {
        SceneManager.LoadScene("level1");
    }
    public void quit()
    {
        Application.Quit();
    }
}
