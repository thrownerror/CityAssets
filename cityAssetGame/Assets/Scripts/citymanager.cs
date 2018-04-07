using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class citymanager : MonoBehaviour {
    [SerializeField]
    Text ammonum;
    [SerializeField]
    Text woodnum;
    [SerializeField]
    Text goldnum;
    [SerializeField]
    Text rocknum;
    int ammo = 0;
    int wood = 0;
    int rock = 0;
    int gold = 0;
    // Use this for initialization
    void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
        ammonum.text = ": "+ammo;
        woodnum.text = ": " + wood;
        rocknum.text = ": " + rock;
        goldnum.text = ": " + gold;
	}

    public void addammo(int a)
    {
        ammo += a;

    }
    public void addwood(int a)
    {
        wood += a;

    }
    public void addrock(int a)
    {
        rock += a;

    }
    public void addgold(int a)
    {
        gold += a;

    }

    public bool useammo(int a)
    {
        if (a <= ammo && ammo > 0)
        {
            ammo -= a;

            return true;
        }
        return false;

    }

    public bool userock(int a)
    {
        if (a <= rock && rock > 0)
        {
            rock -= a;

            return true;
        }
        return false;

    }
    public bool usegold(int a)
    {
        if (a <= gold && gold > 0)
        {
            gold -= a;

            return true;
        }
        return false;

    }
   public bool usewood(int a)
    {
        if (a <= wood && wood > 0)
        {
            wood -= a;

            return true;
        }
        return false;

    }


}
