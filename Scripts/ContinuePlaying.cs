using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuePlaying : MonoBehaviour
{
    public LevelChanger animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KinectHand")
        {
           animator.FadeToLevel("Run");
        }
    }
}
