using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerPlayer2 : MonoBehaviour
{
    public GameObject[] player;
    int selectedplayer;

    void Start()
    {
        selectedplayer = PlayerPrefs.GetInt("Bird_index2", 0);
        foreach (GameObject skin in player) skin.SetActive(false);
        player[selectedplayer].SetActive(true);
    }

    public void NextPlayer()
    {
        Audio.Click();
        player[selectedplayer].SetActive(false);
        selectedplayer++;
        if (selectedplayer >= player.Length) selectedplayer = 0;
        player[selectedplayer].SetActive(true);
        PlayerPrefs.SetInt("Bird_index2", selectedplayer);
    }

    public void PrePlayer()
    {
        Audio.Click();
        player[selectedplayer].SetActive(false);
        selectedplayer--;
        if (selectedplayer < 0) selectedplayer = player.Length - 1;
        player[selectedplayer].SetActive(true);
        PlayerPrefs.SetInt("Bird_index2", selectedplayer);
    }
}
