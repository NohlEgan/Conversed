using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{
    private SpriteRenderer spriteRen;
    private Collider2D coll;
    private KeyCode actionButton;

    [SerializeField]
    private bool colliderIsActive;

    private void Awake()
    {
        actionButton = KeyCode.Space;
        spriteRen = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

        if (colliderIsActive)
        {
            spriteRen.enabled = true;
            spriteRen.color = Color.black;
        }
        else
        {
            spriteRen.enabled = false;
            spriteRen.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(actionButton) && !GameManager.instance.LevelIsOver() && !GameManager.instance.IsGamePaused())
        {
            colliderIsActive = !colliderIsActive;
        }
    }

    private void FixedUpdate()
    {
        coll.enabled = colliderIsActive;

        if (colliderIsActive)
        {
            spriteRen.enabled = true;
        }
        else
        {
            spriteRen.enabled = false;
        }
    }
}
