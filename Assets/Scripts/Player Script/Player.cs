using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private GameObject playerGO;
    public int bombCount;
    public int boostCount;
    public int heartCount;
    public float playerMoveSpeed;
    private void Awake()
    {
        bombCount = startingBombCount;
        boostCount = startingBoostCount;
        heartCount = startingHeartCount;
        playerMoveSpeed = 10f;
        playerGO = gameObject;
    }
    private void Update()
    {
        CountControl();
    }

    public override void CountControl()
    {
        if (heartCount > maxHeartCount)
        {
            heartCount = maxHeartCount;
        }
        if (bombCount > maxBombCount)
        {
            bombCount = maxBombCount;
        }
        if (boostCount > maxBoostCount)
        {
            boostCount = maxBoostCount;
        }
        if (playerMoveSpeed > maxSpeed)
        {
            playerMoveSpeed = maxSpeed;
        }
    }
    public override void Die()
    {
        if (heartCount < 0)
        {
            playerGO.SetActive(false);
            heartCount = startingHeartCount;
        }
    }
    public override void TakeDamage(int amount)
    {

    } 
    
}
