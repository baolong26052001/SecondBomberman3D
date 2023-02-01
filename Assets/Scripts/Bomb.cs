using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;
    public LayerMask layermask;
    private Powerup p;
    public LayerMask breakableWallMask;
    private Player player;
    private BombSpawner bombSpawner;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        p = GameObject.FindWithTag("GameManager").GetComponent<Powerup>();
    }
    private void Start()
    {
        bombSpawner = FindObjectOfType(typeof(BombSpawner)) as BombSpawner;
        StartCoroutine(Explode(Vector3.forward));
        StartCoroutine(Explode(Vector3.right));
        StartCoroutine(Explode(Vector3.back));
        StartCoroutine(Explode(Vector3.left));
        
    }

    IEnumerator Explode(Vector3 direction)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < player.boostCount; i++)
        {
            RaycastHit hit;
            
            Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out hit, i);

            if (!hit.collider)
            {
                GameObject explosion = Instantiate(explosionEffect, transform.position+ i*direction, Quaternion.identity);
                Destroy(gameObject);
                Destroy(explosion,0.5f);
                
            }
            else if (hit.collider.transform.gameObject.CompareTag("uWall"))
            {
                break;
            }
            else if (hit.collider.transform.gameObject.CompareTag("dWall"))
            {
                hit.collider.gameObject.SetActive(false);
                p.DropPowerup(hit.collider.gameObject.transform.position);
                break;

            }
            else if (hit.collider.transform.gameObject.CompareTag("Player"))
            {
                
            } 
        }
    }

    private void OnDestroy()
    {
        bombSpawner.ControlBomb(gameObject);
    }
}
