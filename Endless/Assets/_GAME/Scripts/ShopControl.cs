using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    private int coin = 0;
    private byte positionCharacter = 0;

    public AudioSource soundBtn;
    public Text Coin;
    public Text price;
    public Button[] buy;
    public GameObject[] player;

    private void Update()
    {
        coin = PlayerPrefs.GetInt("Coin");
        Coin.text = PlayerPrefs.GetInt("Coin").ToString();

        switch (positionCharacter)
        {
            default:
            case 0:
                price.color = Color.blue;
                price.text = "Have Owned";
                buy[0].gameObject.SetActive(true);
                buy[1].gameObject.SetActive(false);
                buy[2].gameObject.SetActive(false);
                buy[3].gameObject.SetActive(false);
                buy[4].gameObject.SetActive(false);
                buy[5].gameObject.SetActive(false);
                buy[6].gameObject.SetActive(false);
                break;
            case 1:
                if (PlayerPrefs.HasKey("position1"))
                {
                    price.color = Color.blue;
                    price.text = "Have Owned";
                    buy[1].GetComponentInChildren<Text>().text = "SWITCH";
                }
                else
                {
                    price.color = Color.white;
                    price.text = "60000";
                }
                buy[0].gameObject.SetActive(false);
                buy[1].gameObject.SetActive(true);
                buy[2].gameObject.SetActive(false);
                buy[3].gameObject.SetActive(false);
                buy[4].gameObject.SetActive(false);
                buy[5].gameObject.SetActive(false);
                buy[6].gameObject.SetActive(false);
                break;
            case 2:
                if (PlayerPrefs.HasKey("position2"))
                {
                    price.color = Color.blue;
                    price.text = "Have Owned";
                    buy[2].GetComponentInChildren<Text>().text = "SWITCH";
                }
                else
                {
                    price.color = Color.white;
                    price.text = "50000";
                }
                buy[0].gameObject.SetActive(false);
                buy[1].gameObject.SetActive(false);
                buy[2].gameObject.SetActive(true);
                buy[3].gameObject.SetActive(false);
                buy[4].gameObject.SetActive(false);
                buy[5].gameObject.SetActive(false);
                buy[6].gameObject.SetActive(false);
                break;
            case 3:
                if (PlayerPrefs.HasKey("position3"))
                {
                    buy[3].GetComponentInChildren<Text>().text = "SWITCH";
                    price.color = Color.blue;
                    price.text = "Have Owned";
                }
                else
                {
                    price.color = Color.white;
                    price.text = "65000";
                }

                buy[0].gameObject.SetActive(false);
                buy[1].gameObject.SetActive(false);
                buy[2].gameObject.SetActive(false);
                buy[3].gameObject.SetActive(true);
                buy[4].gameObject.SetActive(false);
                buy[5].gameObject.SetActive(false);
                buy[6].gameObject.SetActive(false);
                break;
            case 4:
                if (PlayerPrefs.HasKey("position4"))
                {
                    price.color = Color.blue;
                    price.text = "Have Owned";
                    buy[4].GetComponentInChildren<Text>().text = "SWITCH";
                }
                else
                {
                    price.color = Color.white;
                    price.text = "50000";
                }
                buy[0].gameObject.SetActive(false);
                buy[1].gameObject.SetActive(false);
                buy[2].gameObject.SetActive(false);
                buy[3].gameObject.SetActive(false);
                buy[4].gameObject.SetActive(true);
                buy[5].gameObject.SetActive(false);
                buy[6].gameObject.SetActive(false);
                break;
            case 5:
                if (PlayerPrefs.HasKey("position5"))
                {
                    price.color = Color.blue;
                    price.text = "Have Owned";
                    buy[5].GetComponentInChildren<Text>().text = "SWITCH";
                }
                else
                {
                    price.color = Color.white;
                    price.text = "20000";
                }
                buy[0].gameObject.SetActive(false);
                buy[1].gameObject.SetActive(false);
                buy[2].gameObject.SetActive(false);
                buy[3].gameObject.SetActive(false);
                buy[4].gameObject.SetActive(false);
                buy[5].gameObject.SetActive(true);
                buy[6].gameObject.SetActive(false);
                break;
            case 6:
                if (PlayerPrefs.HasKey("position6"))
                {
                    price.color = Color.blue;
                    price.text = "Have Owned";
                    buy[6].GetComponentInChildren<Text>().text = "SWITCH";
                }
                else
                {
                    price.color = Color.white;
                    price.text = "20000";
                }
                buy[0].gameObject.SetActive(false);
                buy[1].gameObject.SetActive(false);
                buy[2].gameObject.SetActive(false);
                buy[3].gameObject.SetActive(false);
                buy[4].gameObject.SetActive(false);
                buy[5].gameObject.SetActive(false);
                buy[6].gameObject.SetActive(true);
                break;

        }
    }

    public void OnClick()
    {
        soundBtn.Play();
        switch (positionCharacter)
        {
            default:
            case 0:
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                break;
            case 1:
                if (PlayerPrefs.HasKey("position1"))
                {
                    // What character?
                    PlayerPrefs.SetInt("character", positionCharacter);
                    break;
                }
                else if (coin >= 60000)
                {
                    coin -= 60000;
                    PlayerPrefs.SetString("position1", "bought");
                }
                break;
            case 2:
                if (PlayerPrefs.HasKey("position2"))
                {
                    // What character?
                    PlayerPrefs.SetInt("character", positionCharacter);
                    break;
                }
                else if (coin >= 50000)
                {
                    coin -= 50000;
                    PlayerPrefs.SetString("position2", "bought");
                }
                break;
            case 3:
                if (PlayerPrefs.HasKey("position3"))
                {
                    // What character?
                    PlayerPrefs.SetInt("character", positionCharacter);
                    return;
                }
                if (coin >= 65000)
                {
                    coin -= 65000;
                    PlayerPrefs.SetString("position3", "bought");
                }
                break;
            case 4:
                if (PlayerPrefs.HasKey("position4"))
                {
                    // What character?
                    PlayerPrefs.SetInt("character", positionCharacter);
                    return;
                }
                if (coin >= 50000)
                {
                    coin -= 50000;
                    PlayerPrefs.SetString("position4", "bought");
                }
                break;
            case 5:
                if (PlayerPrefs.HasKey("position5"))
                {
                    // What character?
                    PlayerPrefs.SetInt("character", positionCharacter);
                    return;
                }
                if (coin >= 20000)
                {
                    coin -= 20000;
                    PlayerPrefs.SetString("position5", "bought");
                }
                break;
            case 6:
                if (PlayerPrefs.HasKey("position6"))
                {
                    // What character?
                    PlayerPrefs.SetInt("character", positionCharacter);
                    return;
                }
                if (coin >= 20000)
                {
                    coin -= 20000;
                    PlayerPrefs.SetString("position6", "bought");
                }
                break;
        }
        PlayerPrefs.SetInt("Coin", coin);
    }

    public void NextCharacter()
    {
        soundBtn.Play();
        if (positionCharacter < 6)
        {
            player[positionCharacter].SetActive(false);
            positionCharacter++;
        }
        player[positionCharacter].SetActive(true);
    }

    public void BackCharacter()
    {
        soundBtn.Play();
        if (positionCharacter > 0)
        {
            player[positionCharacter].SetActive(false);
            positionCharacter--;
        }
        player[positionCharacter].SetActive(true);
    }

}

