using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_NoteScript : MonoBehaviour
{
    public bool canBePressed = false;
    public KeyCode theKey;
    public GameObject Button;
    public GameObject NormalHit, GoodHit, PerfectHit, Miss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        KeyCode inputTemp = KeyCode.Space; //temp input to make the touches input a KeyCode
        bool pass = false; // use this to compare the theKey to the KeyCode, set it to true if they are the same
        if (Input.touchCount > 0)
        {
            Touch touchfirst = Input.GetTouch(0);

            if (touchfirst.position.x > Screen.width / 2)
            {

                switch (touchfirst.phase)
                {
                    case TouchPhase.Began:
                        inputTemp = KeyCode.E;
                        break;
                    case TouchPhase.Ended:
                        inputTemp = KeyCode.Space;
                        break;
                }
            }
            else
            {
                switch (touchfirst.phase)
                {
                    case TouchPhase.Began:
                        inputTemp = KeyCode.D;
                        break;
                    case TouchPhase.Ended:
                        inputTemp = KeyCode.Space;
                        break;
                }
            }
            if (Input.touchCount == 2)
            {
                Touch touchSecond = Input.GetTouch(1);

                if (touchSecond.position.x > Screen.width / 2)
                {
                    switch (touchSecond.phase)
                    {
                        case TouchPhase.Began:
                            inputTemp = KeyCode.E;
                            break;
                        case TouchPhase.Ended:
                            inputTemp = KeyCode.Space;
                            break;
                    }
                }
                else
                {
                    switch (touchSecond.phase)
                    {
                        case TouchPhase.Began:
                            inputTemp = KeyCode.D;
                            break;
                        case TouchPhase.Ended:
                            inputTemp = KeyCode.Space;
                            break;
                    }
                }
            }
        }


        if (inputTemp == theKey)
        {
            pass = true;
        }
        else
        {
            pass = false;
        }


        if (Input.GetKeyDown(theKey) || pass)
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                //sc_GM.instance.NoteHit();
                if (transform.position.x > Button.transform.position.x + 0.25 || transform.position.x < Button.transform.position.x - 0.25)
                {
                    //Debug.Log("HIT!");
                    NormalHit.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f));
                    Instantiate(NormalHit, transform.position, NormalHit.transform.rotation);
                    sc_GM.instance.NormalHit();
                }
                else if (transform.position.x > Button.transform.position.x + 0.05 || transform.position.x < Button.transform.position.x - 0.05)
                {
                    //Debug.Log("GOOD!");
                    GoodHit.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f));
                    Instantiate(GoodHit, transform.position, GoodHit.transform.rotation);
                    sc_GM.instance.GoodHit();
                }
                else
                {
                    //Debug.Log("PERFECT!");
                    PerfectHit.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f));
                    Instantiate(PerfectHit, transform.position, PerfectHit.transform.rotation);
                    sc_GM.instance.PerfectHit();
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
            canBePressed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (this.gameObject.activeSelf)
        {
            if (other.tag == "Button")
            {
                canBePressed = false;

                Miss.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f));
                Instantiate(Miss, transform.position, Miss.transform.rotation);

                sc_GM.instance.NoteMiss();
            }
        }
    }
}
