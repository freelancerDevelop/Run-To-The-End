using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int coin = 0;
    public static PlayerController Instance { get; set; }
    private bool isDead;
    public bool IsDead { get { return isDead; } }
    private bool jumpping = false;
    private sbyte currenLane = 0;
    private float speed = 6.0f;
    private Swipe swipe;

    private Animator anim;
    public MenuControl menu;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private CharacterController controller;
    public Text score;
    public AudioSource audio;
    public AudioSource audioDead;


    private void Start()
    {
        Instance = this;
        anim = GetComponentInChildren<Animator>();
        swipe = GetComponent<Swipe>();
        targetPosition = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim.Play("runLoop");

    }

    private void Update()
    {

        if (isDead)
            return;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || swipe.SwipeLeft)
        {
            anim.SetFloat("runLeft", -1);
            ChangLane(-1);

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || swipe.SwipeRight)
        {
            anim.SetFloat("runRight", 1);
            ChangLane(1);
        }
        Vector3 nextPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

    }

    private void Jump()
    {
        jumpping = true;
        if (jumpping)
            targetPosition = new Vector3(currenLane, 1.0f, 0.0f);

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
            if (PlayerPrefs.GetInt("Coin") < coin)
                PlayerPrefs.SetInt("Coin", coin);
            menu.Dead();
        }
    }

}
