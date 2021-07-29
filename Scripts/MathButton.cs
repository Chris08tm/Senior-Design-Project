using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathButton : MonoBehaviour
{
    public LevelChanger animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.FadeToLevel("MathActivities");
    }
}
