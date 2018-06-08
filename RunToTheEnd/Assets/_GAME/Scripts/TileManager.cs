using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
   
    public GameObject[] tilePrefabs;
    private float speed = 2.5f;
    private float maxSpeed = 5.0f;
    private byte cointer = 0;
    private byte leveUp =3;

    private void Update()
    {
        if(cointer == leveUp)
        {
            speed += 0.3f;
            leveUp += 5;
        }

        if (PlayerController.Instance.IsDead)
            return;
        foreach (GameObject tile in tilePrefabs)
        {
            tile.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            if (tile.transform.position.z <= -30.0f)
            {
                tile.transform.position = new Vector3(0, 0, 75.0f);
                cointer++;
            }

        }  
        
    }
 


}
