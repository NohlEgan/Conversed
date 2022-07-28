using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardColourChanger : MonoBehaviour
{
    private SpriteRenderer spriteRen;
    private KeyCode actionButton;

    [SerializeField]
    private bool isWhite;

    private void Awake()
    {
        actionButton = KeyCode.Space;
        spriteRen = GetComponent<SpriteRenderer>();

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
