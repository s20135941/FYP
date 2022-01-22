using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject howToPlayMenu;
    public GameObject playButton;
    // Start is called before the first frame update
    public void OpenHowToPlay()
    {
        howToPlayMenu.SetActive(true);
        playButton.SetActive(false);
    }
    
    public void CloseHowToPlay()
    {
        howToPlayMenu.SetActive(false);
        playButton.SetActive(true);
    }
}
