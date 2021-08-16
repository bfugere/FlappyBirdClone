using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("playButton").GetComponent<Button>().onClick.AddListener(StartGame);
        transform.Find("quitButton").GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        Loader.Load(Loader.Scene.GameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}
