using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class citymanager : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    Text ammonum;
    [SerializeField]
    Text woodnum;
    [SerializeField]
    Text resourcenum;
    [SerializeField]
    Text rocknum;
    [SerializeField]
    Button butt;
    [SerializeField]
    Text butttext;
    Color color1;
    Color color2;
    [SerializeField]
    bool playerturn = true;
    [SerializeField]
    Image redmiddle;
    [SerializeField]
    Image greyupper;
    [SerializeField]
    Image greylower;
    [SerializeField]
    Text roundtext;

    public GameObject cityGrid;
    public GameObject battleGrid;

    public Dictionary<string, UnitScript> units = new Dictionary<string, UnitScript>();


    float time = 0;
    float alph = 1;
    bool l2r = false;
    bool isActionPerformed = false;
    int roundcount = 1;
    int ammo = 0;
    int wood = 0;
    int rock = 0;
    int resource = 0;
    bool meiwan = false;
    bool addedresource;
    public int actionCount = 3;
    public bool gridSwitch = false;

    // Use this for initialization
    void Start()
    {
        color2.r = 0;
        color2.g = 0;
        color2.b = 0;
        color1.r = 1;
        color1.g = 1;
        color1.b = 1;
        //GameObject cityGrid = GameObject.FindGameObjectWithTag("CityGrid") as GameObject;
        //GameObject battleGrid = GameObject.FindGameObjectWithTag("BattleGrid") as GameObject;
        battleGrid.SetActive(false);
    }

    public void AddUnit(string unitCell, UnitScript unit)
    {
        units.Add(unitCell, unit);
    }

    public void RemoveUnit(string unitCell)
    {
        units.Remove(unitCell);
    }

    public void OnTurn()
    {
        actionCount = 3;
        foreach (var unit in units)
        {
            unit.Value.OnTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ammonum.text = ": " + ammo;
        woodnum.text = ": " + wood;
        rocknum.text = ": " + rock;

        resourcenum.text = ": " + resource;
        if (playerturn == false)
        {

            if (alph > 0)
            {

                butt.interactable = false;
                alph = alph - .02f;
                butttext.color = color2;
                ColorBlock cb = butt.colors;
                cb.normalColor = color1;
                cb.disabledColor = color1;
                cb.highlightedColor = color1;
                cb.pressedColor = color1;
                butt.colors = cb;
            }
            if (l2r == false && meiwan == false)
            {

                redmiddle.fillOrigin = (int)Image.OriginHorizontal.Left;
                greylower.fillOrigin = (int)Image.OriginHorizontal.Left;
                greyupper.fillOrigin = (int)Image.OriginHorizontal.Left;
                if (roundtext.gameObject.transform.localPosition.x < 0)
                {

                    roundtext.gameObject.transform.localPosition += new Vector3(9, 0, 0);

                }
                redmiddle.fillAmount += .02f;
                greylower.fillAmount += .02f;
                greyupper.fillAmount += .02f;
                if (redmiddle.fillAmount >= 1)
                {
                    if (time < .1f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .2f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .3f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .4f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .5f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .6f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .7f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .8f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .9f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.0f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.1f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.2f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.3f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.4f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.5f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.6f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.7f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.8f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.9f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 2.0f)
                    {
                        roundtext.color = Color.white;
                    }
                    time += Time.deltaTime;
                    if (time > 2)
                    {
                        roundtext.gameObject.SetActive(false);
                        l2r = true;
                    }
                }



            }
            if (l2r == true && meiwan == false)
            {

                redmiddle.fillAmount -= .02f;
                greylower.fillAmount -= .02f;
                greyupper.fillAmount -= .02f;

                redmiddle.fillOrigin = (int)Image.OriginHorizontal.Right;
                greylower.fillOrigin = (int)Image.OriginHorizontal.Right;
                greyupper.fillOrigin = (int)Image.OriginHorizontal.Right;
                if (redmiddle.fillAmount == 0)
                {
                    meiwan = true;
                }
            }




        }
        else if (playerturn == true)
        {

            if (alph < 1)
            {

                butt.interactable = true;
                alph = alph + .02f;
                butttext.color = color2;
                ColorBlock cb = butt.colors;
                cb.normalColor = color1;
                cb.disabledColor = color1;
                cb.highlightedColor = color1;
                cb.pressedColor = color1;
                butt.colors = cb;

            }


            if (l2r == false && meiwan == false)
            {
                //print("zheli");
                redmiddle.fillOrigin = (int)Image.OriginHorizontal.Left;
                greylower.fillOrigin = (int)Image.OriginHorizontal.Left;
                greyupper.fillOrigin = (int)Image.OriginHorizontal.Left;
                if (roundtext.gameObject.transform.localPosition.x < 0)
                {

                    roundtext.gameObject.transform.localPosition += new Vector3(9, 0, 0);

                }
                redmiddle.fillAmount += .02f;
                greylower.fillAmount += .02f;
                greyupper.fillAmount += .02f;
                if (redmiddle.fillAmount >= 1)
                {
                    if (time < .1f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .2f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .3f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .4f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .5f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .6f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .7f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < .8f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < .9f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.0f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.1f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.2f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.3f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.4f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.5f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.6f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.7f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 1.8f)
                    {
                        roundtext.color = Color.white;
                    }
                    else if (time < 1.9f)
                    {
                        roundtext.color = Color.black;
                    }
                    else if (time < 2.0f)
                    {
                        roundtext.color = Color.white;
                    }
                    time += Time.deltaTime;
                    if (time > 2)
                    {
                        roundtext.gameObject.SetActive(false);
                        l2r = true;
                    }
                }



            }
            if (l2r == true && meiwan == false)
            {

                redmiddle.fillAmount -= .02f;
                greylower.fillAmount -= .02f;
                greyupper.fillAmount -= .02f;

                redmiddle.fillOrigin = (int)Image.OriginHorizontal.Right;
                greylower.fillOrigin = (int)Image.OriginHorizontal.Right;
                greyupper.fillOrigin = (int)Image.OriginHorizontal.Right;
                if (redmiddle.fillAmount == 0)
                {
                    meiwan = true;
                }
            }



        }
        color1.a = alph;
        color2.a = alph;
    }





    public void changeturn()
    {
        if (!playerturn)
        {
            roundcount++;
            roundtext.gameObject.SetActive(true);
            roundtext.text = "Round " + roundcount + ": Your Turn";
            roundtext.transform.localPosition = new Vector3(-594, 8, 0);
            playerturn = false;
            l2r = false;
            meiwan = false;
            playerturn = true;
            time = 0;
            OnTurn();
        }
        else if (playerturn)
        {
            roundtext.gameObject.SetActive(true);
            roundtext.text = "Round " + roundcount + ": Enemies Turn";
            roundtext.transform.localPosition = new Vector3(-594, 8, 0);
            playerturn = false;
            l2r = false;
            meiwan = false;
            time = 0;
        }

    }

    public void addammo(int a)
    {
        ammo += a;

    }
    public void addresource(int a)
    {
        resource += a;


    }
    public void addwood(int a)
    {
        wood += a;

    }
    public void addrock(int a)
    {
        rock += a;

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
    public bool useresource(int a)
    {
        if (a <= resource && resource > 0)
        {
            resource -= a;

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
    public bool IncrementTurn()
    {
        if (actionCount != 0)
        {
            actionCount--;
            return true;
        }

        return false;
    }

    public void onClick()
    {
        if (gridSwitch == true)
        {
            Debug.Log("switched to City Grid");
            gridSwitch = false;
            cityGrid.SetActive(true);
            battleGrid.SetActive(false);
        }
        else if (gridSwitch == false)
        {
            Debug.Log("switched to Battle Grid");
            gridSwitch = true;
            battleGrid.SetActive(true);
            cityGrid.SetActive(false);
        }

    }


}
