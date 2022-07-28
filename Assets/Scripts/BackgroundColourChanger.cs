using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourChanger : MonoBehaviour
{
    private Camera cam;

    private bool isWhite;    

    private KeyCode actionButton;

    private void Awake()
    {
        isWhite = true;
        actionButton = KeyCode.Space;
        cam = GetComponent<Camera>();

        if (isWhite)
        {
            cam.backgroundColor = Color.white;
        }
        else
        {
            cam.backgroundColor = Color.black;
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
            cam.backgroundColor = Color.white;
        }
        else
        {
            cam.backgroundColor = Color.black;
        }
    }
}
