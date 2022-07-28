using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public void GameIsOver()
    {
        GameManager.instance.GoToMenu();
    }
}
