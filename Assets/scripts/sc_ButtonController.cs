using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ButtonController : MonoBehaviour
{
    public GameObject UP, DOWN;
    private SpriteRenderer UpSpriteRenderer, DownSpriteRenderer;
    public Sprite UpDefault, DownDefault;
    public Sprite UpPressed, DownPressed;

    // Start is called before the first frame update
    void Start()
    {
        UpSpriteRenderer = UP.GetComponent<SpriteRenderer>();
        DownSpriteRenderer = DOWN.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Button animation
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpSpriteRenderer.sprite = UpPressed;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            UpSpriteRenderer.sprite = UpDefault;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DownSpriteRenderer.sprite = DownPressed;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            DownSpriteRenderer.sprite = DownDefault;
        }
        


        if (Input.touchCount > 0)
        {
            Touch touchfirst = Input.GetTouch(0);

            if (touchfirst.position.x > Screen.width/2)
            {

                switch (touchfirst.phase)
                {
                    case TouchPhase.Began:
                        UpSpriteRenderer.sprite = UpPressed;
                        break;
                    case TouchPhase.Ended:
                        UpSpriteRenderer.sprite = UpDefault;
                        break;
                }
            }
            else
            {
                switch (touchfirst.phase)
                {
                    case TouchPhase.Began:
                        DownSpriteRenderer.sprite = DownPressed;
                        break;
                    case TouchPhase.Ended:
                        DownSpriteRenderer.sprite = DownDefault;
                        break;
                }
            }
            if (Input.touchCount == 2)
            {
                Touch touchSecond = Input.GetTouch(1);

                if (touchSecond.position.x > Screen.width/2) //> 415)
                {
                    switch (touchSecond.phase)
                    {
                        case TouchPhase.Began:
                            UpSpriteRenderer.sprite = UpPressed;
                            break;
                        case TouchPhase.Ended:
                            UpSpriteRenderer.sprite = UpDefault;
                            break;
                    }
                }
                else
                {
                    switch (touchSecond.phase)
                    {
                        case TouchPhase.Began:
                            DownSpriteRenderer.sprite = DownPressed;
                            break;
                        case TouchPhase.Ended:
                            DownSpriteRenderer.sprite = DownDefault;
                            break;
                    }
                }
            }
        }
    }
}
