using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName ="Powerup")]
public class Powerup : MonoBehaviour //ScriptableObject
{
    /* public string powerupName;
     public Mesh powerupMesh;*/
    public GameObject[] powerups;
    private GameObject go;

    int rndNum;

    public void DropPowerup(Vector3 location)
    {
        rndNum = Random.Range(0, 15);

        switch (rndNum)
        {
            case 1:
                go = Instantiate(powerups[0], location, Quaternion.Euler(-90, 0, 0));
                break;

            case 4:
                go = Instantiate(powerups[1], location, Quaternion.Euler(-90, 0, 0));
                break;

            case 7:
                go = Instantiate(powerups[2], location, Quaternion.Euler(-90, 0, 0));
                break;

            case 12:
                go = Instantiate(powerups[3], location, Quaternion.Euler(-90, 0, 0));
                break;

            default:
                break;
        }
    }
 
}
