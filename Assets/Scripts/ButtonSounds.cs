using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] AudioClip buttonEnterSound;
    [SerializeField] AudioClip buttonClickSound;
    Vector3 gameOverCameraPosition1 = new Vector3(500, -40, 600);

    public void ButtonEnterSound()
    {
        AudioSource.PlayClipAtPoint(buttonEnterSound, gameOverCameraPosition1);
    }

    public void ButtonClickSound()
    {
        AudioSource.PlayClipAtPoint(buttonClickSound, gameOverCameraPosition1);
    }
}
