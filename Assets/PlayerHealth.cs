using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public  int     healthMax = 1000;
    public  int     healthCurrent;
    private int     healthHit;
    private int     healthIncrease = 250;

    public  bool    isAlive;
    public  Text    countdown;

    public  PlayerControls  playerControls;

    void Start()
    {
        isAlive = true;
        healthCurrent = 500;
        //StartCoroutine("Healing");
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            StopCoroutine("Healing");
        }
        */


        if (healthCurrent >= healthMax)
        {
            healthCurrent = healthMax;
        }

        //countdown.text = ("Health " + healthCurrent);
    }

    private void FixedUpdate()
    {
        if (playerControls.isMoving == false)
        {
            StartCoroutine("Healing");
        }
        if (playerControls.isMoving == true)
        {
            StopCoroutine("Healing");
        }
    }

    IEnumerator Healing()
    {
        while (true)
            {
            //yield return new WaitForSeconds(1);
            yield return new WaitForSecondsRealtime(1);
            healthCurrent++;
            yield break;
            }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("HealthBox"))
        {
            print("boop");
            healthMax = healthMax+healthIncrease;
        }
    }
}
