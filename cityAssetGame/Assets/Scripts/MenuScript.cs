using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Button creditsButton;
    public GameObject screen;

    // Use this for initialization
    void Start () {


        Button btn = creditsButton.GetComponent<Button>();
        screen.SetActive(false);
        btn.onClick.AddListener(OpenCredits);

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (Input.GetKeyDown("escape"))
        {
            screen.SetActive(false);
        }

	}

    void OpenCredits()
    {
        screen.SetActive(true);
    }
}
