using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Swipe swipe;
    private sbyte currenLane = 0;
    private bool jumpping = false;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private CharacterController controller;
    private float speed = 10.0f;

    private void Start()
    {
        swipe = GetComponent<Swipe>();
        targetPosition = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
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

        }
    }

}
