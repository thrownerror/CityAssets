using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject enemyGrid;
    GameObject[] gridSpaces;
    bool debugMode = false;
    // Use this for initialization
    void Start()
    {
        gridSpaces = new GameObject[64];
        int moveCount = 0;
        foreach (Transform t in enemyGrid.transform)
        {
            gridSpaces[moveCount] = t.gameObject;
            if (debugMode) { Debug.Log("Found gridSpace"); }

            moveCount++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //   ShootPlayer();
    }

    //Returns an "y_x" string location for a grid location that the player is shooting.
    //Debug log commented out
    public string ShootPlayer()
    {
        string location = "0_0";
        int yLocation = (int)Random.Range(0.0f, 7.9f);
        int xLocation = (int)Random.Range(0.0f, 7.9f);
        location = yLocation + "_" + xLocation;
        if (debugMode) { Debug.Log("Shot Location: " + location); }
        return location;
    }
    //Returns:
    //"damaged" when building damaged but not destroyed
    //"destroyed" when building completly destroyed
    //"hit" when shot connects (possibly deprecated by damaged/destroyed)
    //"missed" when shot misses
    //Assumes the shot will come in as a string "y_x"
    public string ShootEnemy(string shot)
    {
        string shotResult = "";
        bool hitSomething = false;
        foreach (GameObject g in gridSpaces)
        {
            //Check if something is there
            if (g.name == shot)
            {
                hitSomething = true;
                //If g has a building or doesn't equal grass

                //      Get Location asset      GetSprite and check value
                if (g.GetComponent<UnitScript>() != null){//g.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite != null) //|| g.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite != grass

                    g.GetComponent<UnitScript>().OnDamage();    
                    //g.GetComponent<BuildingScript>().TakeDamage();
                    //Or some effect


                    //if(g.GetComponent<BuildingScript>().health != 0)
                    //shotResult = "damaged";
                    //else
                    //shotResult = "destroyed";
                    //if (debugMode) { Debug.Log("Shot Location: " + location); }
                    shotResult = "hit";
                    if (debugMode) { Debug.Log("Shot result: " + shotResult); }
                    return shotResult;
                }
            }
        }
        if (!hitSomething)
        {
            shotResult = "missed";
            if (debugMode) { Debug.Log("Shot result: " + shotResult); }
            return shotResult;
        }
        shotResult = "unreachable";
        if (debugMode) { Debug.Log("Shot result: " + shotResult); }
        return shotResult;

    }
}
