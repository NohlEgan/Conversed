using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButtonPressed()
    {
        AudioManager.instance.PlaySelectionSound();
        SceneManager.LoadScene(1);
    }

    public void ExitButtonPressed()
    {
        AudioManager.instance.PlaySelectionSound();
        Application.Quit();
    }
}
