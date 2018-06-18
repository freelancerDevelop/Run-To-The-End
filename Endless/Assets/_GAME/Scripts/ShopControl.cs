using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    int coin = 0;
    public Text Coin;
    public Text price;
    public Button[] buy;
    public GameObject[] player;
    private byte positionCharacter = 0;

    private void Update()
    {
        coin = PlayerPrefs.GetInt("Coin");
        Coin.text = PlayerPrefs.GetInt("Coin").ToString();

        if (positionCharacter == 0)
        {
            price.text = "0";
            buy[0].gameObject.SetActive(true);
            buy[1].gameObject.SetActive(false);
            buy[2].gameObject.SetActive(false);
            buy[3].gameObject.SetActive(false);
            buy[4].gameObject.SetActive(false);
            buy[5].gameObject.SetActive(false);
            buy[6].gameObject.SetActive(false);

        }
        else if (positionCharacter == 1)
        {

            price.text = "250000";
            buy[0].gameObject.SetActive(false);
            buy[1].gameObject.SetActive(true);
            buy[2].gameObject.SetActive(false);
            buy[3].gameObject.SetActive(false);
            buy[4].gameObject.SetActive(false);
            buy[5].gameObject.SetActive(false);
            buy[6].gameObject.SetActive(false);

            if (PlayerPrefs.HasKey("position1"))
            {
                buy[1].GetComponentInChildren<Text>().text = "SWITCH";
                return;
            }
        }
        else if (positionCharacter == 2)
        {
            price.text = "200000";
            buy[0].gameObject.SetActive(false);
            buy[1].gameObject.SetActive(false);
            buy[2].gameObject.SetActive(true);
            buy[3].gameObject.SetActive(false);
            buy[4].gameObject.SetActive(false);
            buy[5].gameObject.SetActive(false);
            buy[6].gameObject.SetActive(false);

            if (PlayerPrefs.HasKey("position2"))
            {
                buy[2].GetComponentInChildren<Text>().text = "SWITCH";
                return;
            }
        }
        else if (positionCharacter == 3)
        {
            price.text = "180000";
            buy[0].gameObject.SetActive(false);
            buy[1].gameObject.SetActive(false);
            buy[2].gameObject.SetActive(false);
            buy[3].gameObject.SetActive(true);
            buy[4].gameObject.SetActive(false);
            buy[5].gameObject.SetActive(false);
            buy[6].gameObject.SetActive(false);

            if (PlayerPrefs.HasKey("position3"))
            {
                buy[3].GetComponentInChildren<Text>().text = "SWITCH";
                return;
            }
        }
        else if (positionCharacter == 4)
        {
            price.text = "200000";
            buy[0].gameObject.SetActive(false);
            buy[1].gameObject.SetActive(false);
            buy[2].gameObject.SetActive(false);
            buy[3].gameObject.SetActive(false);
            buy[4].gameObject.SetActive(true);
            buy[5].gameObject.SetActive(false);
            buy[6].gameObject.SetActive(false);
            if (PlayerPrefs.HasKey("position4"))
            {
                buy[4].GetComponentInChildren<Text>().text = "SWITCH";
                return;
            }
        }
        else if (positionCharacter == 5)
        {
            price.text = "80000";
            buy[0].gameObject.SetActive(false);
            buy[1].gameObject.SetActive(false);
            buy[2].gameObject.SetActive(false);
            buy[3].gameObject.SetActive(false);
            buy[4].gameObject.SetActive(false);
            buy[5].gameObject.SetActive(true);
            buy[6].gameObject.SetActive(false);

            if (PlayerPrefs.HasKey("position5"))
            {
                buy[5].GetComponentInChildren<Text>().text = "SWITCH";
                return;
            }

        }
        else if (positionCharacter == 6)
        {
            price.text = "80000";
            buy[0].gameObject.SetActive(false);
            buy[1].gameObject.SetActive(false);
            buy[2].gameObject.SetActive(false);
            buy[3].gameObject.SetActive(false);
            buy[4].gameObject.SetActive(false);
            buy[5].gameObject.SetActive(false);
            buy[6].gameObject.SetActive(true);


            if (PlayerPrefs.HasKey("position6"))
            {
                buy[6].GetComponentInChildren<Text>().text = "SWITCH";
                return;
            }
        }

    }

    public void OnClick()
    {
        if (positionCharacter == 0)
        {
            // What character?
            PlayerPrefs.SetInt("character", positionCharacter);
            return;
        }

        else if (positionCharacter == 1)
        {
            if (PlayerPrefs.HasKey("position1"))
            {
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                return;
            }
            if (coin >= 250000)
            {
                coin -= 250000;
                PlayerPrefs.SetString("position1", "bought");
            }
        }
        else if (positionCharacter == 2)
        {
            if (PlayerPrefs.HasKey("position2"))
            {
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                return;
            }
            if (coin >= 200000)
            {
                coin -= 200000;
                PlayerPrefs.SetString("position2", "bought");
            }
        }
        else if (positionCharacter == 3)
        {
            if (PlayerPrefs.HasKey("position3"))
            {
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                return;
            }
            if (coin >= 180000)
            {
                coin -= 180000;
                PlayerPrefs.SetString("position3", "bought");
            }

        }
        else if (positionCharacter == 4)
        {
            if (PlayerPrefs.HasKey("position4"))
            {
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                return;
            }
            if (coin >= 200000)
            {
                coin -= 200000;
                PlayerPrefs.SetString("position4", "bought");
            }
        }
        else if (positionCharacter == 5)
        {
            if (PlayerPrefs.HasKey("position5"))
            {
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                return;
            }
            if (coin >= 80000)
            {
                coin -= 80000;
                PlayerPrefs.SetString("position5", "bought");
            }

        }
        else if (positionCharacter == 6)
        {
            if (PlayerPrefs.HasKey("position6"))
            {
                // What character?
                PlayerPrefs.SetInt("character", positionCharacter);
                return;
            }
            if (coin >= 80000)
            {
                coin -= 80000;
                PlayerPrefs.SetString("position6", "bought");
            }
        }
        PlayerPrefs.SetInt("Coin", coin);
    }

    // Change character.
    public void NextCharacter()
    {
        if (positionCharacter < 6)
        {
            player[positionCharacter].SetActive(false);
            positionCharacter++;
        }
        player[positionCharacter].SetActive(true);
    }
    // Change character.
    public void BackCharacter()
    {
        if (positionCharacter > 0)
        {
            player[positionCharacter].SetActive(false);
            positionCharacter--;
        }
        player[positionCharacter].SetActive(true);
    }

}

