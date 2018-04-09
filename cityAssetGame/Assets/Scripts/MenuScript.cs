using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    public Button playButton;
    public Button creditsButton;
    public Button quitButton;
    public GameObject creditsScreen;

    // Use this for initialization
    void Start () {

        Button pbtn = playButton.GetComponent<Button>();
        Button cbtn = creditsButton.GetComponent<Button>();
        Button qbtn = quitButton.GetComponent<Button>();

        creditsScreen.SetActive(false);

        pbtn.onClick.AddListener(PlayGame);
        cbtn.onClick.AddListener(OpenCredits);
        qbtn.onClick.AddListener(Quit);

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (Input.GetKeyDown("escape"))
        {
            creditsScreen.SetActive(false);
        }

	}

    void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    void Quit()
    {
        Debug.Break();
        Application.Quit();
    }

    void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
