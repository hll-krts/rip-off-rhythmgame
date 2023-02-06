using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_PlayerBehaviour : MonoBehaviour
{
    KeyCode UpKey, DownKey;
    public GameObject ButtonUp, ButtonDown;
    // Start is called before the first frame update
    void Start()
    {
        //UpKey = ButtonUp.GetComponent<sc_ButtonController>().theKey;
        //DownKey = ButtonDown.GetComponent<sc_ButtonController>().theKey;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(UpKey))
        {
            transform.position += new Vector3(0, 2, 0);
            if(transform.position.y > -0.5f){
                transform.position = new Vector3(-12.5f, -0.5f, 0);
                //will play animations later
            }

        }
        if (Input.GetKeyDown(DownKey))
        {
            //will play animations later
        }
    }
}
