using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    public float groundSpeed;
    public Renderer groundRenderer;

    // Update is called once per frame
    void Update()
    {
        groundRenderer.material.mainTextureOffset += new Vector2(groundSpeed * Time.deltaTime, 0f);
    }
}
