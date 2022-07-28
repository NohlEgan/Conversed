using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private AudioClip levelCompleteSound;

    [SerializeField]
    private AudioClip selectionSound;

    [SerializeField]
    private AudioClip switchSound;

    private AudioSource soundPlayer;

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
        soundPlayer = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        soundPlayer.PlayOneShot(jumpSound);
    }

    public void PlayDeathSound()
    {
        soundPlayer.PlayOneShot(deathSound);
    }

    public void PlayLevelCompleteSound()
    {
        soundPlayer.PlayOneShot(levelCompleteSound);
    }

    public void PlaySelectionSound()
    {
        soundPlayer.PlayOneShot(selectionSound);
    }

    public void PlaySwitchSound()
    {
        soundPlayer.PlayOneShot(switchSound);
    }
}
