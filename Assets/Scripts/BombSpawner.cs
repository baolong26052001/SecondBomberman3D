using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public KeyCode placeBomb;
    private  GameObject bombSpawnPosition;
    private Player player; 
    public bool canSpawnBomb;
    private void Start()
    {
        bombSpawnPosition = gameObject.transform.GetChild(0).gameObject;
        player = GetComponent<Player>();
        canSpawnBomb = true;
    }

    private void Update()
    {
        
        CreateBomb();
    }

    void SpawnBomb()
    {
        
            if (canSpawnBomb) 
            {
                CreateBomb();
            }
            

        
    }

    private void CreateBomb()
    {
        if (Input.GetKey(placeBomb))
        {
            if (player.bombCount >= 1)
            {
                player.bombCount -= 1;
                Instantiate(bomb, new Vector3(Mathf.RoundToInt(bombSpawnPosition.transform.position.x),
                    Mathf.RoundToInt(bombSpawnPosition.transform.position.y),
                    Mathf.RoundToInt(bombSpawnPosition.transform.position.z)), Quaternion.identity);
                canSpawnBomb = true;
            }
            else
            {
                canSpawnBomb = false;
            }
        }
    }

    public void ControlBomb(GameObject bomb)
    {
        if (!bomb.activeInHierarchy)
        {
            player.bombCount += 1;
            canSpawnBomb = true;
        }
    }
}
