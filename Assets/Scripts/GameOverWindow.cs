using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highscoreText;

    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();

        transform.Find("retryButton").GetComponent<Button>().onClick.AddListener(RestartGame);
        //transform.Find("retryButton").GetComponent<Button>().AddButtonSounds();

        transform.Find("mainMenuButton").GetComponent<Button>().onClick.AddListener(MainMenu);
        //transform.Find("mainMenuButton").GetComponent<Button>().AddButtonSounds();

        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void RestartGame()
    {
        Loader.Load(Loader.Scene.GameScene);
    }

    public void MainMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

    private void Start()
    {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Loader.Load(Loader.Scene.GameScene);
    }

    private void Bird_OnDied(object sender, EventArgs e)
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();

        if (Level.GetInstance().GetPipesPassedCount() >= Score.GetHighscore())
            highscoreText.text = "****NEW HIGHSCORE****";
        else
            highscoreText.text = "CURRENT HIGHSCORE: " + Score.GetHighscore().ToString();
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
