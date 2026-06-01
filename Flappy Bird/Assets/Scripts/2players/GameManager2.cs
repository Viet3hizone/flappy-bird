using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager2 : MonoBehaviour
{
    public Player2[] player;
    public Player2_2[] player2;
    private Player2 bird;
    private Player2_2 bird2;
    private Spawner spawner;
    public Text player1Score,player2Score, endScore2, endScore1;
    public Button playButton, MenuButton;
    public GameObject gameOver;
    int birdIndex, birdIndex2; 
    int flag = -1; 
    public int score1 { get; private set; }
    public int score2 { get; private set; }

    private void Awake()
    {
        birdIndex = PlayerPrefs.GetInt("Bird_index",0);
        birdIndex2 = PlayerPrefs.GetInt("Bird_index2", 0); 
        bird = Instantiate(player[birdIndex], Vector3.zero, Quaternion.identity);
        bird2 = Instantiate(player2[birdIndex2], new Vector3(3, 0, 0), Quaternion.identity);
        Application.targetFrameRate = 60;
        spawner = FindObjectOfType<Spawner>();
    }
    private void Start()
    {
        player1Score.enabled = true;
        player2Score.enabled = true; 
        score1 = 0;
        score2 = 0; 
        player1Score.text = score1.ToString();
        player2Score.text = score2.ToString();
        Time.timeScale = 1f;
        bird.enabled = true;
        bird2.enabled = true; 
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void GameOver(string name)
    {
        flag++;
        StartCoroutine(Stop(name,flag)) ;
        if (flag == 1)
        {
            gameOver.SetActive(true);
            player1Score.enabled = false;
            player2Score.enabled = false; 
            endScore1.text = score1.ToString();
            endScore2.text = score2.ToString();
            Time.timeScale = 0f; 
        }
    }
    public void LoadScene()
    {
        Audio.Click();
        if (SceneManager.GetActiveScene().buildIndex == 7) SceneManager.LoadScene(6);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Stop(string name,int flag)
    {
        if(name == "player2") bird2.enabled = false;
        else bird.enabled = false;
        if (flag == 0) {
            yield return new WaitForSeconds(0.3f);
            if (bird2.enabled == false) Destroy(bird2.gameObject);
            else Destroy(bird.gameObject);
        }    
    }

    public void IncreaseScoreForPlayer1()
    {
        score1++;
        player1Score.text = score1.ToString();
    }
    public void IncreaseScoreForPlayer2()
    {
        score2++;
        player2Score.text = score2.ToString();
    }
    public void ToMenu()
    {
        Audio.Click();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
