using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_PlayerScript : MonoBehaviour
{
    public GameObject PlayerObject;
    private SpriteRenderer PlayerRenderer;
    public Sprite Run1, Run2, Slide, Jump;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRenderer = PlayerObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
