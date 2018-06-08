using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }

    private void OnDisable()
    {
        Invoke("Invisible", 2.0f);
    }

    private void Invisible()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {

        gameObject.SetActive(false);

        if (PlayerController.Instance.IsDead)
            return;
    }
}
