using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 180f;
    public float speedChanger = -1.15f;
    public bool increaseSpeed;
    public bool changeDirection;


    // Update is called once per frame
    public void Awake()
    {
        changeDirection = MenuManager.changeDirectionBool;
        increaseSpeed = MenuManager.increaseSpeedBool;
    }
    void Update()
    {
        changeDirection = MenuManager.changeDirectionBool;
        increaseSpeed = MenuManager.increaseSpeedBool;
        if(increaseSpeed)
        {
            if(changeDirection)
            {
                speedChanger = -1.15f;
            }
            else
            {
                speedChanger = 1.15f;
            }
        }
        else
        {
            if (changeDirection)
            {
                speedChanger = -1f;
            }
            else
            {
                speedChanger = 1f;
            }
        }




        if (speed <= -325)
        {
            speed = -325;
        }
        else if(speed >= 325)
        {
            speed = 325;
        }
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
