using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UnitLevel
{
    Level1 = 1,
    Level2,
    Level3
};

public class UnitScript : MonoBehaviour
{
    public ItemType unitType;
    public UnitLevel unitLevel;

    public string currentCell;

    public int unitHealth;
    private int unitNumber;
    private int damageAmount;
    private int repairAmount;

    public int resourceIncrement;
    public int ammoIncrement;

    private int resourceCount;
    private int ammoCount;
    citymanager manager;

    [SerializeField]
    Button donebutton;
    bool add = false;
    
	void Start ()
    {
        unitLevel = UnitLevel.Level1;
        unitManager();
        manager = GameObject.Find("CityManager").GetComponent<citymanager>();
        damageAmount = 30;
        
    }

    public void Init()
    {
        unitManager();
    }

    void Update() {
        
        //if (donebutton.interactable == false && add == false)
        //{
        //    OnTurn();
        
        //    add = true;

        //}
        //else if (donebutton.interactable == true)
        //{
        //    add = false;
        //}
    }

    public bool CanUpgrade()
    {
        if (unitLevel == UnitLevel.Level3) return false;
        else if (unitType == ItemType.GENERIC)
        {
            return false;
        }
        return true;
    }

    public bool UpgradeLevel()
    {
        if (unitLevel == UnitLevel.Level3) return false;

        if (unitType == ItemType.GENERIC)
        {
            return false;
        }
        else
        {
            unitLevel = unitLevel + 1;
            ammoIncrement++;
            resourceIncrement++;
            unitHealth += 15;
        }

        return true;
    }

    public void unitManager()
    {
        switch (unitType)
        {
            case ItemType.RESOURCE_GEN:
                print("Resource Generator");
                unitNumber = 3;
                unitHealth = 30;
                resourceIncrement = 1;
                break;

            case ItemType.AMMO_GEN:
                print("Ammo Generator");
                unitNumber = 2;
                unitHealth = 20;
                ammoIncrement = 1;               
                break;

            case ItemType.GENERIC:
                print("Generic Building");
                unitNumber = 1;
                unitHealth = 10;
                break;

            default:
                print("Generic Building");
                unitNumber = 1;
                break;
        }
    }

    public void OnTurn()
    {
        switch(unitType)
        {
            case ItemType.AMMO_GEN:
                manager.GetComponent<citymanager>().addammo(ammoIncrement);
                break;
            case ItemType.RESOURCE_GEN:
                manager.GetComponent<citymanager>().addresource(resourceIncrement);
                break;
            case ItemType.GENERIC:
                //Do nothing
                break;
        }
    }

    public void OnDamage()
    {
        unitHealth -= damageAmount;
        if (unitHealth <= 0)
        {
            manager.RemoveUnit(currentCell);
            Destroy(gameObject);
        }
        //if (unitType == 1)
        //{
           
          
        //}
        //if (unitNumber == 2)
        //{
        //    unitHealth -= damageAmount;
        //    if (unitHealth <= 0)
        //    {
        //        //destroy
        //    }
        //}
        //if (unitNumber == 3)
        //{
        //    unitHealth -= damageAmount;
        //    if (unitHealth <= 0)
        //    {
        //        //destroy
        //    }
        //}
    }

    public void OnRepair()
    {
        if (unitType == ItemType.GENERIC)
        {
            //subtract resources from city manager
            //cannot repair this guy
        }
        if (unitType == ItemType.AMMO_GEN)
        {
            //subtract resources from city manager
            manager.GetComponent<citymanager>().useresource(1);
            unitHealth += repairAmount;
            unitHealth += Mathf.Clamp(repairAmount, 0, 2);
        }
        if (unitType == ItemType.RESOURCE_GEN)
        {
            //subtract resources from city manager
            manager.GetComponent<citymanager>().useresource(1);
            unitHealth += repairAmount;
            unitHealth += Mathf.Clamp(repairAmount, 0, 3);
        }
    }
}
