using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Audio : MonoBehaviour
{
    static AudioSource[] audioManager;
    static public AudioClip jump, click, hit;
    private static Audio instance = null;
    public static Audio Instance
    {
        get
        {
            return instance; 
        }
    }
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); 
        audioManager = Instance.gameObject.GetComponents<AudioSource>();
        jump = Resources.Load<AudioClip>("CasualGameSounds/DM-CGS-07");
        click = Resources.Load<AudioClip>("CasualGameSounds/DM-CGS-20");
        hit = Resources.Load<AudioClip>("CasualGameSounds/DM-CGS-11");
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            FindObjectOfType<OnOffButton>().Changesoundbutton(audioManager[0].mute);
            FindObjectOfType<OnOffButton>().Changemusicbutton(audioManager[1].mute);
        }
    }
    static public void Jump()
    {
        if (audioManager[1].mute == false) audioManager[1].PlayOneShot(jump);
    }
    static public void Click()
    {
        if (audioManager[1].mute == false) audioManager[1].PlayOneShot(click);
    }
    static public void Hit()
    {
        if (audioManager[1].mute == false) audioManager[1].PlayOneShot(hit);
    }
    static public void musicAdjust()
    {
        Click(); 
        audioManager[1].mute = !audioManager[1].mute;
        FindObjectOfType<OnOffButton>().Changemusicbutton(audioManager[1].mute);
    }
    static public void soundAdjust()
    {
        Click(); 
        audioManager[0].mute = !audioManager[0].mute;
        FindObjectOfType<OnOffButton>().Changesoundbutton(audioManager[0].mute);
    }
}
