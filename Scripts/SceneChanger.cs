using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void switchSceneRun(){
        Score.score = 1;
        SceneManager.LoadScene("Run");
    }

    public void switchSceneStart(){
        Score.score = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
