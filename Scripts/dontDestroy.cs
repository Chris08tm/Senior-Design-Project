using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public GameObject kinect1;
    public GameObject kinect2;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(kinect1);
        DontDestroyOnLoad(kinect2);
    }

    
}
