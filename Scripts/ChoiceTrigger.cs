using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTrigger : MonoBehaviour
{
    public GameObject prompt;
    public GameObject correctMessage;
    public GameObject incorrectMessage;
    public GameObject otherChoice1;
    public GameObject otherChoice2;
    public GameObject continueButton;
    private bool isChosen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KinectHand")
        {
            otherChoice2.SetActive(false);
            otherChoice1.SetActive(false);
            continueButton.SetActive(true);
            if(isChosen)
            {
                prompt.SetActive(false);
                correctMessage.SetActive(true);
            }else
            {
                prompt.SetActive(false);
                incorrectMessage.SetActive(true);
            }
        }
        
    }

    public void setChosen(bool b)
    {
        this.isChosen = b;
    }

}
