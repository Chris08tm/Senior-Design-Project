using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMaxScore : MonoBehaviour
{
    public Text displayScoreText;

    // Start is called before the first frame update
    void Start()
    {   
        
        displayScoreText.text = "Highest Score:   " + ((int)Score.score).ToString();
    }

}
