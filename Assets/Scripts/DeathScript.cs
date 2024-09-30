using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            transform.position = new Vector3((float)-16.21, 8.43f, 0 );
        }
        if (other.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3((float)-16.21, 8.43f, 0);
        }
    }
}
