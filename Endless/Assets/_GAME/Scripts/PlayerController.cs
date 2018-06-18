using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int oldCoin;
    private int coin = 0;
    public static PlayerController Instance { get; set; }
    private bool isDead;
    public bool IsDead { get { return isDead; } }
    private bool jumping = false;
    private float jump = 0.0f;
    private sbyte currenLane = 0;
    private float speed = 6.0f;
    private Swipe swipe;
    private Vector3 jumpPosition;

    private Animator anim;
    public MenuControl menu;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private CharacterController controller;
    public Text score;
    public AudioSource audio;
    public AudioSource audioDead;
    public GameObject[] players;

    private void Start()
    {
        int positionCharacter = PlayerPrefs.GetInt("character");
        for (int i = 0; i < 7; i++)
        {
            players[i].gameObject.SetActive(false);
            if (i == positionCharacter)
                players[i].SetActive(true);
        }

        Instance = this;
        anim = GetComponentInChildren<Animator>();
        swipe = GetComponent<Swipe>();
        targetPosition = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim.Play("runLoop");
        oldCoin = PlayerPrefs.GetInt("Coin");

    }

    private void Update()
    {

        if (isDead)
            return;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || swipe.SwipeLeft)
        {

            ChangLane(-1);

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || swipe.SwipeRight)
        {

            ChangLane(1);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || swipe.SwipeUp)
        {

        }

        Vector3 nextPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if (jumping)
        {
            if (transform.position.y == 0)
            {
                jumping = false;
                return;
            }
            else
            {
                rb.velocity = new Vector3(currenLane, -10 * Time.deltaTime, 0);
            }
        }
    }

    private void ChangLane(sbyte target)
    {
        sbyte targetLane = (sbyte)(currenLane + target);
        if (targetLane < -1 || targetLane > 1)
            return;
        currenLane = targetLane;
        targetPosition = new Vector3(targetLane, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            audio.Play();
            coin++;
            score.text = coin.ToString();
        }
        if (other.CompareTag("Enemy"))
        {
            isDead = true;
            audioDead.Play();
            anim.Play("LOSE00");
            PlayerPrefs.SetInt("Coin", coin + oldCoin);


            menu.Dead();
        }
    }

}
