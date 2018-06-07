using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin: " + other.tag);
    }
}
