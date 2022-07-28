using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool levelOver;
    private bool paused;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);

        levelOver = false;
        paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !levelOver && !paused)
        {
            paused = true;
            Time.timeScale = 0f;
            UIManager.instance.ShowPauseScreen();
        }
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        AnimationPlayer.instance.PlayTransitionAnimation();
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        levelOver = false;
    }

    public IEnumerator GoToNextLevel()
    {
        AnimationPlayer.instance.PlayTransitionAnimation();
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        levelOver = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        levelOver = true;
        AnimationPlayer.instance.PlayDeathAnimation();
        StartCoroutine(Death());
    }

    public void Win()
    {
        levelOver = true;

        if (SceneManager.sceneCountInBuildSettings != SceneManager.GetActiveScene().buildIndex + 1)
        {
            StartCoroutine(GoToNextLevel());
        }
        else
        {
            UIManager.instance.ShowEndScreen();
        }
    }

    public bool LevelIsOver()
    {
        return levelOver;
    }

    public bool IsGamePaused()
    {
        return paused;
    }

    public void SetGamePaused(bool isPaused)
    {
        paused = isPaused;
    }
}
