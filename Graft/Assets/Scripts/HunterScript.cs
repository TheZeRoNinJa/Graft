using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour
{
    [SerializeField] RenderTexture pixelationRenderer;

    Vector2 rendererStartingSize;

    // Start is called before the first frame update
    void Start()
    {
        rendererStartingSize = pixelationRenderer.texelSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
