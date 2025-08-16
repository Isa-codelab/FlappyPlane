using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Renderer gameBackground;

    private float xOffsset = 0;

    private Vector2 textureOffset;
    // Start is called before the first frame update
    void Start()
    {
       gameBackground = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        xOffsset += 0.1f * Time.deltaTime;

        textureOffset.x = xOffsset;

        gameBackground.material.mainTextureOffset = textureOffset;
    }
}
