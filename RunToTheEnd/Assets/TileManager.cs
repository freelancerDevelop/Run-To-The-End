using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private float speed = 2.0f;
    private float maxSpeed = 5.0f;
    private void Update()
    {
        foreach (GameObject tile in tilePrefabs)
        {
            tile.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            if (tile.transform.position.z <= -30.0f)
                tile.transform.position = new Vector3(0, 0, 75.0f);
        }  
        
    }
 


}
