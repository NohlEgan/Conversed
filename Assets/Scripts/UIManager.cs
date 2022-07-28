using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private GameObject endScreen;

    private void Awake()
    {
        instance = this;
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    public void ShowPauseScreen()
    {
        AudioManager.instance.PlaySelectionSound();
        pauseScreen.SetActive(true);
    }

    public void ShowEndScreen()
    {
        endScreen.SetActive(true);
    }

    public void ResumeButtonPressed()
    {
        AudioManager.instance.PlaySelectionSound();
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        GameManager.instance.SetGamePaused(false);
    }

    public void MenuButtonPressed()
    {
        AudioManager.instance.PlaySelectionSound();
        Time.timeScale = 1f;
        GameManager.instance.GoToMenu();
        GameManager.instance.SetGamePaused(false);
    }
}
