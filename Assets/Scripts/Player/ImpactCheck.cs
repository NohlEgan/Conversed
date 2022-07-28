using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactCheck : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            AudioManager.instance.PlayLevelCompleteSound();
            GameManager.instance.Win();
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Spiky"))
        {
            AudioManager.instance.PlayDeathSound();
            GameManager.instance.Lose();
            Destroy(gameObject);
        }
    }
}
