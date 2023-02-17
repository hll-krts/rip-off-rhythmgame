using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_PlayerBehaviour : MonoBehaviour
{
    KeyCode UpKey, DownKey;
    public GameObject ButtonUp, ButtonDown;
    Vector3 FirstLocation;
    // Start is called before the first frame update
    void Start()
    {
        FirstLocation = transform.position;
        //UpKey = ButtonUp.GetComponent<sc_ButtonController>().theKey;
        //DownKey = ButtonDown.GetComponent<sc_ButtonController>().theKey;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touchfirst = Input.GetTouch(0);

            if (touchfirst.position.x > Screen.width / 2)
            {
                switch (touchfirst.phase)
                {
                    case TouchPhase.Began:
                        transform.position += new Vector3(0, 2, 0);
                        if (transform.position.y > -0.5f)
                        {
                            transform.position = new Vector3(transform.position.x, -0.5f, 0);
                            //will play animations later
                        }
                        break;
                }
            }
            else{
                switch (touchfirst.phase)
                {
                    case TouchPhase.Began:
                        transform.position = FirstLocation;
                        break;
                }
            }
        }
    }
}

