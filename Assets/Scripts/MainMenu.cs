using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int mainMenuBuildIndex = 0;
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MainMenu");
    }

    // Update is called once per frame
    public void Exit()
    {
        Debug.Log("QUIT !!");
        Application.Quit();

    }
}
