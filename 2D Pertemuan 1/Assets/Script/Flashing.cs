using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public bool start = false;
    public SpriteRenderer spriteRenderer;

    public Material matWhite;
    private Material matDefault;

    // Start is called before the first frame update
    void Start()
    {
        matDefault = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            spriteRenderer.material = matWhite;
            Invoke("ResetMaterial", .1f);
        }
    }

    void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
        start = false;
    }
}
