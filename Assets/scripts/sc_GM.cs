using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_GM : MonoBehaviour
{
    public AudioSource Musik;
    public bool StartPLaying;
    public sc_BeatScroller BullShit;
    public static sc_GM instance;

    public Text scoreText;
    public Text multiText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public float totalNotes, NormalHits, GoodHits, PerfectHits, MissedHits;
    public GameObject resultScreen;
    public Text percentHitText, NormalText, GoodText, PerfectText, MissedText, RankText, FinaleSkorText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<sc_NoteScript>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartPLaying)
        {
            if (Input.anyKeyDown)
            {
                StartPLaying = true;
                BullShit.StartControl = true;

                Musik.Play();
            }
        }
        else
        {
            if (!Musik.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);

                NormalText.text = NormalHits.ToString();
                GoodText.text = GoodHits.ToString();
                PerfectText.text = GoodHits.ToString();
                MissedText.text = MissedHits.ToString();

                float totalHits = GoodHits + NormalHits + PerfectHits;
                float percentageHits = (totalHits / totalNotes) * 100;

                percentHitText.text = percentageHits.ToString("F1") + "%";

                if (percentageHits > 0)
                {
                    RankText.text = "F";
                    if (percentageHits > 40)
                    {
                        RankText.text = "D";
                        if (percentageHits > 50)
                        {
                            RankText.text = "C";
                            if (percentageHits > 60)
                            {
                                RankText.text = "B";
                                if (percentageHits > 75)
                                {
                                    RankText.text = "A";
                                    if (percentageHits > 85)
                                    {
                                        RankText.text = "S";
                                        if (percentageHits > 95)
                                        {
                                            RankText.text = "SS";
                                            if (percentageHits > 99)
                                            {
                                                RankText.text = "SSS";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                FinaleSkorText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        NormalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        GoodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        PerfectHits++;
    }
    public void NoteMiss()
    {
        //Debug.Log("Miss");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        MissedHits++;
    }
}
