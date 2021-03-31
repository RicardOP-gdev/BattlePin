using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PinP1 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPinned = false;
    public float speed = 20f;    
    public float screenSize;
    public bool gameHasEnded;
    public AudioSource niceShoot;
    public AudioSource badShoot;
    



    public Rigidbody2D rb;
    

    
    private void Update()
    {
       
        screenSize = Mathf.Max(Screen.width, Screen.height); 
        if (!isPinned)
        rb.MovePosition(rb.position + Vector2.right * screenSize * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Rotator")
        {
            if(FindObjectOfType<AlarmManager>().gameHasEnded == false)
            {
                transform.SetParent(col.transform);
                col.GetComponent<Rotator>().speed *= col.GetComponent<Rotator>().speedChanger;
                Score.PinCount++;
                isPinned = true;
                niceShoot.Play();
                AlarmManager.turnP1 = false;
            }
            else
            {
                transform.SetParent(col.transform);
                col.GetComponent<Rotator>().speed *= col.GetComponent<Rotator>().speedChanger;
                isPinned = true;
                badShoot.Play();
            }
            
        }else if(col.tag == "Pin" && AlarmManager.turnP1 == true)
        {
           if(AlarmManager.coop == true) FindObjectOfType<AlarmManager>().EndGame();
           if(AlarmManager.coop == false) FindObjectOfType<AlarmManager>().P2Win();
        }
        else if (col.tag == "Pin" && AlarmManager.turnP1 == false)
        {
            if (AlarmManager.coop == true) FindObjectOfType<AlarmManager>().EndGame();
            if (AlarmManager.coop == false) FindObjectOfType<AlarmManager>().P1Win();
        }
    }
}
