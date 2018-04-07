using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGen : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    GameObject citymanager;
    [SerializeField]
    int lvl = 1;
    [SerializeField]
    float time = 0;
    [SerializeField]
    float spd = 1;
    // Use this for initialization
    void Start()
    {
        citymanager = GameObject.Find("CityManager");


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spd)
        {
            citymanager.GetComponent<CityManager>().addgold(lvl);
            time = 0;

        }
    }
}
