using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int coin = 0;
    private bool isDead;
    private bool jumpping = false;
    private sbyte currenLane = 0;
    private float speed = 6.0f;
    private Swipe swipe;

    public MenuControl menu;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private CharacterController controller;
    public Text score;
    private AudioSource  audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        swipe = GetComponent<Swipe>();
        targetPosition = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (isDead)
            return;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || swipe.SwipeLeft)
            ChangLane(-1);
        else if
         (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || swipe.SwipeRight)
            ChangLane(1);

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
            PlayerPrefs.SetInt("Coin", coin);
            menu.Dead();
        }
    }

}
