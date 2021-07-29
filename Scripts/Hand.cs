using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour
{
    public Transform mHandMesh;

    // Update is called once per frame
    void Update()
    {  
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Math")
        {
            SceneManager.LoadScene("MathActivities");
        }else if(collision.tag == "WordPuzzle")
        {
            SceneManager.LoadScene("WordPuzzleActivities");
        }
    }
}
