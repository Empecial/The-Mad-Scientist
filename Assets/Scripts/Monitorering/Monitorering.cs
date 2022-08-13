using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitorering : MonoBehaviour
{
    // denne kode blev lavet med inspiration fra https://www.youtube.com/watch?v=ijAN0QI70UU 

    // Tid siden spillet startede samt tiden for alle de individuelle spørgsmål
    public Text timePassed;
    private float timeCounter = 0;

    public Text timeSpent1stQuestion, timeSpent2ndQuestion, timeSpent3rdQuestion, timeSpent4thQuestion, timeSpent5thQuestion, timeSpent6thQuestion, PlayerPosX, PlayerPosZ;

    public GameObject Question1Time, MonitoreringsMetoder;

    private bool BaggrundsMusikTrigger, DebugActive, ActivateTimer = false;

    AudioSource BaggrundsMusik;

    public void Start()
    {
        DebugMenu(false);

        //float Question1TimeText = float.Parse(Question1Time.GetComponentInChildren<Text>().text);

        BaggrundsMusik = GameObject.FindGameObjectWithTag("Player").GetComponent<MusicAndSounds>().BaggrundsMusik;
    }

    public void DebugMenu(bool n)
    {
        MonitoreringsMetoder.SetActive(n);
    }

    private void OnTriggerEnter(Collider other)
    {

        Starter(other);

        CorrectAnswers(other);
    }

    void Starter(Collider other)
    {
        if (other.gameObject.name == "Starter" && !BaggrundsMusikTrigger && !ActivateTimer)
        {
            BaggrundsMusik.Play();
            BaggrundsMusikTrigger = true;
            ActivateTimer = true;
        }
    }

    void CorrectAnswers(Collider other)
    {
        /* Tjekker om hvis gameobjectet som spilleren ramme
         har det navn der er det samme som der er specificeret 
        og sætter den målte tid til at være mængden af tid det tog
        for at finde dette gameobject */

        if (other.gameObject.name == "Ag")
        {
            timeSpent1stQuestion.text = timeCounter.ToString();
        }
        else if (other.gameObject.name == "Laptop - Molar")
        {
            timeSpent2ndQuestion.text = timeCounter.ToString();
        }
        else if (other.gameObject.name == "Laptop - CO2")
        {
            timeSpent3rdQuestion.text = timeCounter.ToString();
        }
        else if (other.gameObject.name == "laptop - Lvl 2 - Opg 1 - Korrekt")
        {
            timeSpent4thQuestion.text = timeCounter.ToString();
        }
        else if (other.gameObject.name == "laptop - Lvl 2 - Opg 2 - Korrekt")
        {
            timeSpent5thQuestion.text = timeCounter.ToString();
        }
        else if (other.gameObject.name == "laptop - Lvl 2 - Opg 3 - Korrekt")
        {
            timeSpent6thQuestion.text = timeCounter.ToString();
        }
    }

    void Update()
    {

        if (ActivateTimer)
        {
            timer();
        }
        

        PlayerPosition();

        DebugMenuControl();

    }

    void DebugMenuControl()
    {
        if (Input.GetKeyUp(KeyCode.F12) == true && !DebugActive)
        {
            DebugMenu(true);
            DebugActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.F12) == true && DebugActive)
        {
            DebugMenu(false);
            DebugActive = false;
        }
    }

    void PlayerPosition()
    {
        /* Finder positionen af spillerens x og z position. */
        PlayerPosX.text = this.transform.position.x.ToString();

        PlayerPosZ.text = this.transform.position.z.ToString();
    }

    void timer()
    {
        /* Dette tilføjer Time.DeltaTime ovenpå timeCounters værdi som er = 0 og 
       * skriver det ud til timePassed.text så det bliver vist inde i spillet*/
        timeCounter += Time.deltaTime;
        timePassed.text = timeCounter.ToString();
    }




}
