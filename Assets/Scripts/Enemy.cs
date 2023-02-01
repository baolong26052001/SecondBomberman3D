using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int bombCount;
    public int boostCount;
    public int heartCount;
    public float playerMoveSpeed;

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
        
    }

    public override void TakeDamage(int amount)
    {
       
    }
}
