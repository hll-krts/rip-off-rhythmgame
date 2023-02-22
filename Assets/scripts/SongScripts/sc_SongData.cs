using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class sc_SongData : MonoBehaviour
{

    public AudioClip[] AllSongs;
    [SerializeField] private SongData _SongData = new SongData();
    // Start is called before the first frame update
    public GameObject[] UpNotes, DownNotes, MirrorNotes;
    string songData;

    void Start()
    {
        Debug.Log(AllSongs[0].name.Split("_")[1]);
        UpNotes = GameObject.FindGameObjectsWithTag("noteUp");
        DownNotes = GameObject.FindGameObjectsWithTag("noteDown");
        MirrorNotes = GameObject.FindGameObjectsWithTag("mirrorNote");
        SaveSongData();

        SaveToFile();
        ReadFromFile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SaveSongData()
    {
        SongData sDO = new SongData();

        // Populate them with the correct values
        // Try not to hardcode them, well aside from the unavoidable ones
        sDO.SongID = int.Parse(AllSongs[1].name.Split("_")[0]);
        sDO.songName = AllSongs[sDO.SongID].name.Split("_")[1];
        sDO.songArtist = AllSongs[sDO.SongID].name.Split("_")[2];
        sDO.songAudioPath = "\\" + AllSongs[sDO.SongID].name + ".mp3";
        sDO.songTempo = float.Parse(AllSongs[sDO.SongID].name.Split("_")[3]);
        sDO.songDifficulty = int.Parse(AllSongs[sDO.SongID].name.Split("_")[4]);
        //sDO.songNotes = new List<SongNotes>();

        for (int i = 0; i < UpNotes.Length; i++)
        {
            SongNotes sNTempU = new SongNotes();
            sNTempU.noteName = UpNotes[i].name;
            sNTempU.noteTag = UpNotes[i].tag;
            sNTempU.notePosition = UpNotes[i].transform.position;
            sDO.songNotes.Add(sNTempU);
        }

        for (int i = 0; i < DownNotes.Length; i++)
        {
            SongNotes sNTempD = new SongNotes();
            sNTempD.noteName = DownNotes[i].name;
            sNTempD.noteTag = DownNotes[i].tag;
            sNTempD.notePosition = DownNotes[i].transform.position;
            sDO.songNotes.Add(sNTempD);
        }

        for (int i = 0; i < MirrorNotes.Length; i++)
        {
            SongNotes sNTempM = new SongNotes();
            sNTempM.noteName = MirrorNotes[i].name;
            sNTempM.noteTag = MirrorNotes[i].tag;
            sNTempM.notePosition = MirrorNotes[i].transform.position;
            sDO.songNotes.Add(sNTempM);
        }

        _SongData = sDO;

    }

    [System.Serializable]
    public class SongData
    {
        public int SongID;
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
        public string noteName;
        public string noteTag;
        public Vector3 notePosition;
    }

    private void SaveToFile()
    {
        songData = JsonUtility.ToJson(_SongData);
        System.IO.File.AppendAllText(Application.dataPath + "\\SongData.json", songData);
    }

    private void ReadFromFile()
    {
        _SongData = JsonUtility.FromJson<SongData>(songData);
    }
}
