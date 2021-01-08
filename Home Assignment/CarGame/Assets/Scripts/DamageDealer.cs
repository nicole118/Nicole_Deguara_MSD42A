using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    //the amount of damage the obstacle gives
    [SerializeField] int damageAmount1 = 1;
    

    //the damage received
    public int GetDamage()
    {
        return damageAmount1;
    }


    //destroys the object
    public void Hit()
    {
        Destroy(gameObject);
    }

}
