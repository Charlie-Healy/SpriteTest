using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public GameObject player;
    SpriteRenderer sr;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX=false;
        }
        
    }   

    
}

