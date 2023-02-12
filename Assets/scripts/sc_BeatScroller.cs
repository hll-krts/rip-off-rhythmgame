using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_BeatScroller : MonoBehaviour
{
    public float Tempo;
    public bool StartControl;
    
    public bool isMirrored;
    // Start is called before the first frame update
    void Start()
    {
        isMirrored = false;
        Tempo = Tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartControl)
        {
            /*if (Input.anyKeyDown)
            {
                StartControl = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(Tempo * Time.deltaTime, 0f, 0f);
        }
    }
}
