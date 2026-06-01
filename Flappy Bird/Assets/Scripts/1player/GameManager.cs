using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Player[] player;
    private Player bird; 
    private Spawner spawner;
    public int bestscore;
    public Text scoreText, bestScore, endScore;
    public Button playButton, MenuButton;
    public GameObject gameOver;
    int birdIndex; 
    public int score { get; private set; }
   
    private void Awake()
    {
        birdIndex = PlayerPrefs.GetInt("Bird_index");
        bird=Instantiate(player[birdIndex], Vector3.zero, Quaternion.identity); 
        Application.targetFrameRate = 60;
        spawner = FindObjectOfType<Spawner>();
        bestscore = PlayerPrefs.GetInt("Key_data", -1);
    }
    private void Start()
    {
        scoreText.enabled = true;
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1f;
        bird.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void GameOver()
    {
        Audio.Hit(); 
        if (score > bestscore)
        {
            bestscore = score;
            PlayerPrefs.SetInt("Key_data", bestscore);
        }
        gameOver.SetActive(true);
        scoreText.enabled = false;
        endScore.text = score.ToString();
        bestScore.text = bestscore.ToString(); 
        Stop();
    }
    public void LoadScene()
    {
        Audio.Click();
        if (SceneManager.GetActiveScene().buildIndex == 5) SceneManager.LoadScene(2);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Stop()
    {
       Time.timeScale = 0f;
       bird.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void ToMenu()
    {
        Audio.Click();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f; 
    }
}
