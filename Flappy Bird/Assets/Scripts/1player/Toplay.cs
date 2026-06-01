using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Toplay : MonoBehaviour
{
    public GameObject pauseTable;
    public Text bestScore;
    private void Awake()
    {
        bestScore.text = PlayerPrefs.GetInt("Key_data").ToString(); 
    }
    public void Option()
    {
        Audio.Click();
        pauseTable.SetActive(true);
    }
    public void back()
    {
        Audio.Click(); 
        pauseTable.SetActive(false); 
    }
    public void play()
    {
        Audio.Click();
     
        SceneManager.LoadScene(2); 
    }
    public void playfor2()
    {
        Audio.Click();
        SceneManager.LoadScene(6);
    }
}
