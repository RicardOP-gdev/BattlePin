using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasSettings;
    public static float winCondition =10;
    public static bool increaseSpeedBool =true;
    public static bool changeDirectionBool = true;
    public Text winConditionText;
    public Toggle increase;
    public Toggle change;
    public Toggle turn;
    public static bool turnActive = true;
    public static bool musicActive = true;
    public static bool sfxActive = true;
    public AudioMixer audioMixer;
    public Button musicB;
    public Texture musicOnT;
    public Texture musicOffT;
    public Button sfxB;
    public Texture sfxOnT;
    public Texture sfxOffT;
    public AudioSource secondaryButton;
    public AudioSource primaryButton;


    public void Update()
    {
        if(increaseSpeedBool)
        {
            increase.isOn = true;
        }
        else
        {
            increase.isOn = false;
        }

        if (changeDirectionBool)
        {
            change.isOn = true;
        }
        else
        {
            change.isOn = false;
        }

        if (turnActive)
        {
           turn.isOn = true;
        }
        else
        {
            turn.isOn = false;
        }

        if (musicActive)
        {
            audioMixer.SetFloat("MusicVolume", 0);
            musicB.GetComponent<RawImage>().texture = musicOnT;
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", -80);
            musicB.GetComponent<RawImage>().texture = musicOffT;
        }

        if (sfxActive)
        {
            audioMixer.SetFloat("SFXVolume", 0);
            sfxB.GetComponent<RawImage>().texture = sfxOnT;
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", -80);
            sfxB.GetComponent<RawImage>().texture = sfxOffT;
        }

        winConditionText.text = winCondition.ToString();
    }

    public void GoCoop()
    {
        canvasMenu.SetActive(true);
        canvasSettings.SetActive(false);
        SceneManager.LoadScene("GameCoop", LoadSceneMode.Single);
        AlarmManager.coop = true;
    }

    public void GoVs()
    {
        canvasMenu.SetActive(true);
        canvasSettings.SetActive(false);
        SceneManager.LoadScene("GameCoop", LoadSceneMode.Single);
        AlarmManager.coop = false;
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Close Game");
    }

    public void ToggleCanvas()
    {
        if(canvasMenu.activeSelf ==true)
        {
            canvasMenu.SetActive(false);
            canvasSettings.SetActive(true);
        }
        else if(canvasSettings.activeSelf == true)
        {
            canvasMenu.SetActive(true);
            canvasSettings.SetActive(false);
        }
    }

    public void ToggleMusic()
    {
        if (musicActive)
        {
            musicActive =false;
            Debug.Log("Me silencio");
        }
        else 
        {
            musicActive = true;
            Debug.Log("Me desilencio");
        }
    }

    public void ToggleSFX()
    {
        if (sfxActive)
        {
            sfxActive = false;
        }
        else
        {
            sfxActive = true;
        }
    }


    public void SetWinCondition(float winConditionSlider)
    {
        winCondition = winConditionSlider;
        winConditionText.text = winCondition.ToString();
    }

    public void SetIncreaseSpeed(bool increaseSpeed)
    {
        increaseSpeedBool = increaseSpeed;
    }

    public void SetChangeDirection(bool changeDirection)
    {
        changeDirectionBool = changeDirection;
    }

    public void SetTurnPlay(bool turnPlayer)
    {
        turnActive = turnPlayer;
    }

    public void PrimaryButton()
    {
        primaryButton.Play();
    }

    public void SecondaryButton()
    {
        secondaryButton.Play();
    }
}
