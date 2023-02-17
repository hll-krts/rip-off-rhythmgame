using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu, SongsMenu, SettingsMenu, CharacterMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        SongsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CharacterMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButton()
    {
        MainMenu.SetActive(false);
        SongsMenu.SetActive(true);
    }

    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void CharacterButton()
    {
        MainMenu.SetActive(false);
        CharacterMenu.SetActive(true);
    }
}
