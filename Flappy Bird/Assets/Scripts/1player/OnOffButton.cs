using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class OnOffButton:MonoBehaviour
{
    public Button soundButton;
    public Button musicButton;
    public Sprite soundOnButton, soundOffButton, musicOnButton, musicOffButton;

    public void Changesoundbutton(bool indexsound)
    {
        soundButton.image.overrideSprite = (indexsound == false) ? soundOnButton : soundOffButton;
    }
    public void Changemusicbutton(bool indexmusic)
    {
        musicButton.image.overrideSprite = (indexmusic == false) ? musicOnButton : musicOffButton;
    }
}
