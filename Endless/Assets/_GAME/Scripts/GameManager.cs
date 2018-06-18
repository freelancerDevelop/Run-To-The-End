using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject quit;
    public AudioSource audio;
    public void Option(bool choose)
    {
        quit.SetActive(choose);
    }
    public void Play()
    {
        SceneManager.LoadScene("1_Game");
        AdmobManager.Instance.RequestBanner();
        audio.Play();

    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
