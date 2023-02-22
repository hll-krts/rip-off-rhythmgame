using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_LoadSong : MonoBehaviour
{

    public GameObject noteHolder, upNoteP, downNoteP, mirrorNoteP;

    // Start is called before the first frame update
    void Start()
    {
        LoadFromFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class SongList
    {   
        public List<SongData> songDataFromFile = new List<SongData>();
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
    private void LoadFromFile()
    {
        string tempData = System.IO.File.ReadAllText(Application.dataPath + "\\SongData.json");

        // You can make it so you load the correct song by changing                  this v     value to the id you want, the index of the song it self could be an id
        SongData songDataLoad = JsonUtility.FromJson<SongList>(tempData).songDataFromFile[0]; //but if you want to use the SongData.ID, then you can load them back to
                                                                                              //a list then getting the SongData.ID of the song you selected
        Debug.Log(songDataLoad.songName);

        for (int i = 0; i < songDataLoad.songNotes.Count; i++)
        {
            GameObject upNotePT = upNoteP;
            GameObject downNotePT = downNoteP;
            GameObject mirrorNotePT = mirrorNoteP;
            switch(songDataLoad.songNotes[i].noteTag)
            {
                case "noteUp":
                    Instantiate(upNotePT, songDataLoad.songNotes[i].notePosition, upNotePT.transform.rotation, noteHolder.transform);
                    break;
                case "noteDown":
                    Instantiate(downNotePT, songDataLoad.songNotes[i].notePosition, downNotePT.transform.rotation, noteHolder.transform);
                    break;
                case "mirrorNote":
                    Instantiate(mirrorNotePT, songDataLoad.songNotes[i].notePosition, mirrorNotePT.transform.rotation, noteHolder.transform);
                    break;
                default:
                    Debug.Log("Index: " + i + " does not contain a proper tag.");
                    break;
                
            }
        }



    }
}
