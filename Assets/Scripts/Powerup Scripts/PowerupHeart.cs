using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHeart : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<Player>();
        if (other.gameObject.CompareTag("Player"))
        {    
            gameObject.SetActive(false);
            player.heartCount++;
        }
    }
}
