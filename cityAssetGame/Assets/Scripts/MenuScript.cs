using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Button creditsButton;
    public Button quitButton;
    public GameObject screen;

    // Use this for initialization
    void Start () {


        Button cbtn = creditsButton.GetComponent<Button>();
        Button qbtn = quitButton.GetComponent<Button>();
        screen.SetActive(false);
        cbtn.onClick.AddListener(OpenCredits);
        qbtn.onClick.AddListener(Quit);

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

    void Quit()
    {
        Application.Quit();
    }
}
