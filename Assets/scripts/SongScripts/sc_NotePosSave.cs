using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class sc_NotePosSave : MonoBehaviour
{

    [SerializeField] private SongData _SongData = new SongData();
    // Start is called before the first frame update
    public GameObject[] UpNotes, DownNotes, MirrorNotes;
    string[] mirrorNote, upNote, downNote;
    
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
        SaveUpNotePos();
        SaveDownNotePos();
        SaveMirrorNotePos();

        SaveToFile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public class SongData
    {
        public string songName;
        public string songArtist;
        public string songAudioPath;
        public float songTempo;
        public int songDifficulty;
        public List<SongNotes> songNotes = new List<SongNotes>();
    }


    [System.Serializable]
    public class SongNotes
    {
        public GameObject[] topNotes;
        public GameObject[] botNotes;
        public GameObject[] mirrorNotes;
    }

    private void SaveToFile()
    {
        string songData = JsonUtility.ToJson(_SongData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/SongData.json", songData);
    }

    private void SaveUpNotePos()
    {
        upNote = new string[UpNotes.Length];
        for (int i = 0; i < UpNotes.Length; i++)
        {
            NotePos upNotePosition = new NotePos
            {
                Name = UpNotes[i].name,
                notePos = UpNotes[i].transform.position
            };
            upNote[i] = JsonUtility.ToJson(upNotePosition);
        }
    }
    private void SaveDownNotePos()
    {
        downNote = new string[DownNotes.Length];
        for (int i = 0; i < DownNotes.Length; i++)
        {
            NotePos downNotePosition = new NotePos
            {
                Name = DownNotes[i].name,
                notePos = DownNotes[i].transform.position
            };
            downNote[i] = JsonUtility.ToJson(downNotePosition);
        }
    }

    private void SaveMirrorNotePos()
    {
        mirrorNote = new string[MirrorNotes.Length];
        for (int i = 0; i < MirrorNotes.Length; i++)
        {
            NotePos mirrorNotePosition = new NotePos
            {
                Name = MirrorNotes[i].name,
                notePos = MirrorNotes[i].transform.position
            };
            mirrorNote[i] = JsonUtility.ToJson(mirrorNotePosition);
        }
        /*foreach (string value in mirrorNote)
        {
            Debug.Log(value);
        }*/
    }

    public class NotePos
    {
        public string Name;
        public Vector3 notePos;
    }
}
