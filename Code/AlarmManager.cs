using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlarmManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public Rotator rotator;
    public Rotator rotatorVs;
    public Spawner spawner;
    public GameObject[] pins;
    public GameObject canvasGameOver;
    public GameObject canvasWin;
    public Animator animatorCamera;
    public Button P1;
    public Button P1Vs;
    public Button P2;
    public Button P2Vs;
    public float winCondition = 10;
    public AudioSource secondaryButton;
    public AudioSource primaryButton;
    public static bool turnP1;
    public static bool winningP1;

    public float timerRoundP1;
    public Text timerRoundP1T; 
    public Text timerRoundP1TW; 
    public Text timerRoundP1TL; 
    public float timerRoundP2;
    public float maxTime;
    public Text timerRoundP2T;
    public Text timerRoundP2TW;
    public Text timerRoundP2TL;
    public GameObject winP2C;
    public GameObject winP1C;
    public GameObject crownP1;
    public GameObject crownP2;
    public GameObject canvasCoop;
    public GameObject canvasVs;
    public GameObject arrowP1;
    public GameObject arrowP1Vs;
    public GameObject arrowP2;
    public GameObject arrowP2Vs;
    public static bool coop;
    public static bool winP1;
    public static bool winP2;
    public static bool player1Win;
    
    
    


    public void Awake()
    {
        winCondition = MenuManager.winCondition;
    }
    public void Update()
    {
        if (!coop)
        {
            if(winP1)
            {
                winP1C.SetActive(true);
                winP2 = false;
            }
            else if(winP2)
            {
                winP2C.SetActive(true);
                winP1 = false;
            }
            canvasVs.SetActive(true);
            canvasCoop.SetActive(false);
            if(Score.PinCount >= winCondition && player1Win)
            {
                P1Win();
            }
            else if (Score.PinCount >= winCondition && !player1Win)
            {
                P2Win();
            }
            if (turnP1 && !gameHasEnded)
            {
                //Turn player 1
                timerRoundP1 += Time.deltaTime;

            }
            else if (!turnP1 && !gameHasEnded)
            {
                //Turn player 2
                timerRoundP2 += Time.deltaTime;

            }
            if (!gameHasEnded)
            {
                if (timerRoundP1 < timerRoundP2)
                {
                    player1Win = true;
                    crownP1.SetActive(true);
                    crownP2.SetActive(false);

                }
                else if (timerRoundP1 > timerRoundP2)
                {
                    player1Win = false;
                    crownP2.SetActive(true);
                    crownP1.SetActive(false);

                }
            }
            else
            {
                crownP2.SetActive(false);
                crownP1.SetActive(false);
            }

            timerRoundP1T.text = timerRoundP1.ToString("#.0");
            timerRoundP1TW.text = timerRoundP1.ToString("#.0");
            timerRoundP1TL.text = timerRoundP1.ToString("#.0");
            timerRoundP2T.text = timerRoundP2.ToString("#.0");
            timerRoundP2TW.text = timerRoundP2.ToString("#.0");
            timerRoundP2TL.text = timerRoundP2.ToString("#.0");           
        }
        else
        {
            canvasCoop.SetActive(true);
            canvasVs.SetActive(false);
        }

        winCondition = MenuManager.winCondition;
        pins = GameObject.FindGameObjectsWithTag("Pin");
        if(!gameHasEnded)
        {

                canvasGameOver.SetActive(false);
                canvasWin.SetActive(false);
                winP1C.SetActive(false);
                winP2C.SetActive(false);

            if (MenuManager.turnActive)
            {
                if (turnP1)
                {
                    P1.enabled = true;
                    P1Vs.enabled = true;
                    arrowP1Vs.SetActive(true);
                    arrowP1.SetActive(true);
                    P2.enabled = false;
                    P2Vs.enabled = false;
                    arrowP2Vs.SetActive(false);
                    arrowP2.SetActive(false);
                }
                else
                {
                    P2.enabled = true;
                    P2Vs.enabled = true;
                    arrowP2Vs.SetActive(true);
                    arrowP2.SetActive(true);
                    P1.enabled = false;
                    P1Vs.enabled = false;
                    arrowP1Vs.SetActive(false);
                    arrowP1.SetActive(false);
                }
            }
            
        }
        else
        {
            P1.enabled = false;
            P2.enabled = false;
        }
        
        if(Score.PinCount >= winCondition)
        {
            WinGame();
        }
    }

    public void PrimaryButton()
    {
        primaryButton.Play();
    }

    public void SecondaryButton()
    {
        secondaryButton.Play();
    }

    public void EndGame()
    {
        if (gameHasEnded)
        {
            return;
        }
        rotator.enabled = false;
        rotatorVs.enabled = false;
        spawner.enabled = false;
        if(coop)animatorCamera.SetTrigger("EndGame");
        
        gameHasEnded = true;
        if (coop) canvasGameOver.SetActive(true);
       /* else if (!coop && winP1) winP1C.SetActive(true);
        else if (!coop && winP2) winP2C.SetActive(true);*/

    }
    public void P2Win()
    {
        gameHasEnded = true;
        Debug.Log("P2 Win");
        rotatorVs.enabled = false;
        spawner.enabled = false;
        winP2C.SetActive(true);
        winP2 =true;
        winP1 =false;
        crownP1.SetActive(false);
        crownP2.SetActive(false);
    }

    public void P1Win()
    {
        gameHasEnded = true;
        Debug.Log("P1 Win");
        rotatorVs.enabled = false;
        spawner.enabled = false;
        winP1C.SetActive(true);
        winP1 = true;
        winP2 = false;
        crownP1.SetActive(false);
        crownP2.SetActive(false);
    }

    public void RestartGame()
    {
        gameHasEnded = false; ;
        rotator.enabled = true;
        rotatorVs.enabled = true;
        spawner.enabled = true;
        rotator.speed = 180;
        rotatorVs.speed = 180;
        GameObject.FindGameObjectsWithTag("Pin");
        foreach (GameObject pin in pins)
        Destroy(pin);
        if (coop) animatorCamera.SetTrigger("RestartGame");
        timerRoundP1 = 0;
        timerRoundP2 = 0;
        Score.PinCount = 0;
        winP1 = false;
        winP2 = false;
    }

    public void WinGame()
    {
        if (gameHasEnded)
        {
            return;
        }
        rotator.enabled = false;
        rotatorVs.enabled = false;
        spawner.enabled = false;
        if(coop)animatorCamera.SetTrigger("WinGame"); 
        gameHasEnded = true;
        if(coop)canvasWin.SetActive(true);
       /* else if(!coop && winP1)winP1C.SetActive(true);
        else if(!coop && winP2)winP2C.SetActive(true);*/
    }

    public void BackGame()
    {
        gameHasEnded = false; ;
        rotator.enabled = true;
        rotatorVs.enabled = true;
        spawner.enabled = true;
        rotator.speed = 180;
        rotatorVs.speed = 180;
        GameObject.FindGameObjectsWithTag("Pin");
        foreach (GameObject pin in pins)
        Destroy(pin);
        if (coop) animatorCamera.SetTrigger("RestartGame");        
        timerRoundP1 = 0;
        timerRoundP2 = 0;

        Score.PinCount = 0;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    
}
