using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler.Start");
        Debug.Log("Current Highscore: " + PlayerPrefs.GetInt("highscore"));

        Score.Start();
    }
}
