using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    

    protected int startingBombCount = 1;
    protected int startingBoostCount = 2;
    protected int startingHeartCount = 1;
    protected int maxBombCount = 4;
    protected int maxBoostCount = 5;
    protected int maxHeartCount = 3;
    protected int maxSpeed = 18;  
    public abstract void CountControl();

    public abstract void Die();
    public abstract void TakeDamage(int amount);

}
    
