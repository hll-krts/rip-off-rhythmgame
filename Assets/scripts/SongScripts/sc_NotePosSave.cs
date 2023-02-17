using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_NotePosSave : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] UpNotes, DownNotes, MirrorNotes;
    string[] json;
    void Start()
    {
        /*NotePos notePosition = new NotePos{
            notePos = this.transform.position
        };
        string json = JsonUtility.ToJson(notePosition);
        Debug.Log(json);*/
        UpNotes = GameObject.FindGameObjectsWithTag("noteUp");
        DownNotes = GameObject.FindGameObjectsWithTag("noteDown");
        MirrorNotes = GameObject.FindGameObjectsWithTag("mirrorNote");
        for (int i = 0; i < MirrorNotes.Length; i++)
        {
            NotePos notePosition = new NotePos
            {
                notePos = MirrorNotes[i].transform.position
            };
            json[i] = JsonUtility.ToJson(notePosition);
        }
        Debug.Log(json);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SaveNotePos()
    {

    }

    public class NotePos
    {
        public Vector2 notePos;
    }
}
