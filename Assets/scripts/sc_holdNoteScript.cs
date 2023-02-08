using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_holdNoteScript : MonoBehaviour
{
    public GameObject holdStart, holdStop, inBetween;
    Vector3 inBetweenScale, inBetweenPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        inBetweenScale = new Vector3(holdStop.transform.position.x - holdStart.transform.position.x, 1, 1);
        inBetweenPos = new Vector3(holdStart.transform.position.x + (holdStop.transform.position.x - holdStart.transform.position.x) / 2, holdStart.transform.position.y, holdStart.transform.position.z);
        inBetween.transform.position = inBetweenPos;
        inBetween.transform.localScale = inBetweenScale;
        //Debug.Log(inBetween.transform.position);
    }
}
