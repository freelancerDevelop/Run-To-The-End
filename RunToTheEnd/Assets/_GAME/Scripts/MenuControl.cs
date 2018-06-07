using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject[] menu;

    public void Pause()
    {
        Time.timeScale = 0.0f;
        menu[0].SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        menu[0].SetActive(false);
    }

    public void Reset()
    {
        
    }
}
