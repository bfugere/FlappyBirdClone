using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static void Start()
    {
        Bird.GetInstance().OnDied += Bird_OnDied;
    }

    private static void Bird_OnDied(object sender, EventArgs e)
    {
        TrySetNewHighscore(Level.GetInstance().GetPipesPassedCount());
    }

    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore");
    }

    public static bool TrySetNewHighscore(int score)
    {
        int currentHighscore = GetHighscore();
        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            return true;
        }
        else
            return false;
    }
}
