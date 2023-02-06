using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ButtonController : MonoBehaviour
{
    private SpriteRenderer theSpriteRenderer;
    public Sprite Default;
    public Sprite Pressed;

    public KeyCode theKey;

    // Start is called before the first frame update
    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(theKey))
        {
            theSpriteRenderer.sprite = Pressed;
        }
        if (Input.GetKeyUp(theKey))
        {
            theSpriteRenderer.sprite = Default;
        }
    }
}
