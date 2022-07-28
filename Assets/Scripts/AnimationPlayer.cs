using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private Animator transitionAnim;

    [SerializeField]
    private Animator deathAnim;

    public static AnimationPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayTransitionAnimation()
    {
        transitionAnim.SetBool("SceneEnd", true);
    }

    public void PlayDeathAnimation()
    {
        deathAnim.SetBool("Death", true);
    }
}
