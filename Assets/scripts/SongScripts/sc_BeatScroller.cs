using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_BeatScroller : MonoBehaviour
{
    public float Tempo;
    public bool StartControl;
    
    public bool isMirrored;
    GameObject[] UpNotes, DownNotes, MirrorNotes;
    // Start is called before the first frame update
    void Start()
    {
        
        UpNotes = GameObject.FindGameObjectsWithTag("noteUp");
        DownNotes = GameObject.FindGameObjectsWithTag("noteDown");
        MirrorNotes = GameObject.FindGameObjectsWithTag("mirrorNote");
        for(int i = 0; i<MirrorNotes.Length; i++){
            Debug.Log(MirrorNotes[i].transform.position.x);
        }
        isMirrored = false;
        Tempo = Tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartControl)
        {
            transform.position -= new Vector3(Tempo * Time.deltaTime, 0f, 0f);
        }
    }
}
