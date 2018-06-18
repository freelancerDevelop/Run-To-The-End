﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject[] menu;
    public Text topScore;
    public AudioSource sound,soundbtn;
    
    public void Pause()
    {
        Time.timeScale = 0.0f;
        menu[0].SetActive(true);
        menu[1].SetActive(false);
    }

    public void Dead()
    {
        sound.Play();
        topScore.text = PlayerPrefs.GetInt("Coin").ToString();
        menu[1].SetActive(false);
        menu[2].SetActive(true);
        AdmobManager.Instance.ShowRewardBasedVideo();

    }

    public void Resume()
    {
        soundbtn.Play();
        Time.timeScale = 1.0f;
        menu[0].SetActive(false);
        menu[1].SetActive(true);
    }

    public void PlayAgain()
    {
        soundbtn.Play();
        menu[0].SetActive(false);
        menu[1].SetActive(true);
        menu[2].SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }
    public void Shop()
    {
        soundbtn.Play();
        SceneManager.LoadScene("Shop");
    }
    public void OnHome()
    {
        soundbtn.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Home");
    }
}
