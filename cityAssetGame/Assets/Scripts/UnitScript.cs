﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    //check building type
    //get component from city management
    // do whatever it is supposed to do

        //Generic building is number 1 
        //Ammo Generator is number 2 
        //Resource Generator is number 3

    private int unitType;
    private int unitHealth;
    private int unitNumber;
    private int damageAmount;
    private int repairAmount;
    //CityManager cityManager;

	
	void Start ()
    {
		
	}

    public void unitManager()
    {
        switch (unitType)
        {
            case 1:
                print("Resource Generator");
                unitNumber = 3;
                unitHealth = 30;
                
                break;
            case 2:
                print("Ammo Generator");
                unitNumber = 2;
                unitHealth = 20;
                //get ammo count from city manager and ++
                break;
            case 3:
                print("Generic Building");
                unitNumber = 1;
                unitHealth = 10;
                break;
            //does nothing, only exists, like me

            default:
                print("Generic Building");
                unitNumber = 1;
                break;

        }


    }

    public void OnTurn()
    {
        if (unitNumber == 1)
        {
            //DO nothing
        }
        if (unitNumber == 2)
        {
            //get ammo count from city manager and increase it
        }
        if (unitNumber == 3)
        {
            //get resource count from city manager and increase it
        }
    }
    public void OnDamage()
    {
        if (unitNumber == 1)
        {
            unitHealth -= damageAmount;
            if (unitHealth <= 0)
            {
                //destroy
            }
               
               
        }
        if (unitNumber == 2)
        {
            unitHealth -= damageAmount;
            if (unitHealth <= 0)
            {
                //destroy
            }
        }
        if (unitNumber == 3)
        {
            unitHealth -= damageAmount;
            if (unitHealth <= 0)
            {
                //destroy
            }
        }
    }

    public void OnRepair()
    {
        if (unitNumber == 1)
        {
            //subtract resources from city manager
            //cannot repair this guy
        }
        if (unitNumber == 2)
        {
            //subtract resources from city manager
            unitHealth += Mathf.Clamp(repairAmount, 0, 2);
        }
        if (unitNumber == 3)
        {
            //subtract resources from city manager
            unitHealth += repairAmount;
            unitHealth += Mathf.Clamp(repairAmount, 0, 3);
        }
    }
}
