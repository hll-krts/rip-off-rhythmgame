using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_mirrorNoteScript : MonoBehaviour
{
    //canBePressed used for detecting if it's colliding with buttons
    public bool canBePressed;
    //mirrorNote is actually this object
    public GameObject Kamera, mirrorNote;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Button")
        {
            //multiplies Kamera's Z position with "-1" 
            Kamera.transform.position = new Vector3(Kamera.transform.position.x, Kamera.transform.position.y, Kamera.transform.position.z * -1f);
                
            if(GameObject.Find("noteHolder").GetComponent<sc_BeatScroller>().isMirrored == false)
            {
                    //if Kamera's Y rotation is can't divided by 360, rotate it 180 degrees (Kamera Y rotation is 180 or -180)
                if (Mathf.Abs(Kamera.transform.rotation.y % 360) != 0)
                {
                    Kamera.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                    //if Kamera's Y rotation is can divided by 360, rotate it 180 degrees (Kamera Y rotation is 0 or 360)
                else if (Mathf.Abs(Kamera.transform.rotation.y % 360) == 0)
                {
                    Kamera.transform.rotation = Quaternion.Euler(0, -180, 0);
                }

                GameObject.Find("noteHolder").GetComponent<sc_BeatScroller>().isMirrored = true;
            } else 
            {
                Kamera.transform.rotation = Quaternion.Euler(0, 0, 0);

                GameObject.Find("noteHolder").GetComponent<sc_BeatScroller>().isMirrored = false;
            }
        }
    }
}
