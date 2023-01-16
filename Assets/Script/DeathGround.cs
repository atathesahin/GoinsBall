using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGround : MonoBehaviour
{
    public Vector3 checkPos;
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player")
        {
            
            player.transform.position = checkPos;
            
        }
    }
}
