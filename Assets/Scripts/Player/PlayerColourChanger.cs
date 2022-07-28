using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColourChanger : MonoBehaviour
{
    private SpriteRenderer spriteRen; 

    private bool isWhite;    

    private KeyCode actionButton;

    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        actionButton = KeyCode.Space;

        isWhite = false;

        if (isWhite)
        {
            spriteRen.color = Color.white;
        }
        else
        {
            spriteRen.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(actionButton) && !GameManager.instance.LevelIsOver() && !GameManager.instance.IsGamePaused())
        {
            AudioManager.instance.PlaySwitchSound();
            isWhite = !isWhite;
        }
    }

    private void FixedUpdate()
    {
        if (isWhite)
        {
            spriteRen.color = Color.white;
        }
        else
        {
            spriteRen.color = Color.black;
        }
    }
}
