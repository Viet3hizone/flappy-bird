using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Tomenu : MonoBehaviour
{
    public AudioSource aus;
    private AudioClip aul; 
    private void Start()
    {
        aul = Resources.Load<AudioClip>("CasualGameSounds/DM-CGS-26"); 
        StartCoroutine(tomenu());
        StartCoroutine(playsound()); 
    }
    IEnumerator tomenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1); 
    }
    IEnumerator playsound()
    {
        yield return new WaitForSeconds(0.5f);
        aus.PlayOneShot(aul); 
    }
}
