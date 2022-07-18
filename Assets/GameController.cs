using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI text;
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    // Update is called once per frame
    private void Start()
    {
        Screen.SetResolution(1000, 600, false);
        audioSource = GetComponent<AudioSource>();
        playListSound(0);
    }

    public void playListSound(int listNum)
    {
        audioSource.clip = audioClip[listNum];
        audioSource.Play();
    }

    public void handleButton(string buttonFunction)
    {
        if (buttonFunction == "EnterMainMenu")
        {
            SceneManager.LoadScene(0);
        }

        if (buttonFunction == "PlayGame")
        {
            SceneManager.LoadScene(1);
        }

        if (buttonFunction == "ExitGame")
        {
            Application.Quit();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            handleButton("EnterMainMenu");
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) { return; }

        text.text = playerScore.ToString() + " - " + enemyScore.ToString();
    }
}
