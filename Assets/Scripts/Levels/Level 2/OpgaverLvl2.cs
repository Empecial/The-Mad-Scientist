using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpgaverLvl2 : MonoBehaviour
{

    [SerializeField] GameObject Lvl2Opgave2, Lvl2Opgave2Rigtig, Lvl2Opgave2Falsk, Lvl2Opgave2Falsk2, Lvl2Opgave3, Lvl2Opgave3Rigtig, Lvl2Opgave3Falsk, Lvl2Opgave3Falsk2, LeChateliersPrincipPåvirkning, Lvl2Færdig, Lvl2SecretWall;
    [SerializeField] BoxCollider SecretTriggerLvl3;


    bool Lvl2Opgave1Done, Lvl2Opgave2Done, Lvl2ErFærdig = false;

    private void Update()
    {
        if (Lvl2ErFærdig==true)
        {
            Lvl2SecretWall.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "laptop - Lvl 2 - Opg 1 - Korrekt")
        {
            Lvl2Opgave2.SetActive(true);
            Lvl2Opgave1Done = true; 
            Lvl2Opgave2Active(true);
        }
        else if (other.gameObject.name== "laptop - Lvl 2 - Opg 2 - Korrekt")
        {
            Lvl2Opgave2Done = true; 
            Lvl2Opgave3Active(true);
            Lvl2Opgave3.SetActive(true);
            LeChateliersPrincipPåvirkning.SetActive(true);

        }
        else if (other.gameObject.name == "laptop - Lvl 2 - Opg 3 - Korrekt")
        {
            Lvl2Færdig.SetActive(true);
            Lvl2ErFærdig=true;
            SecretTriggerLvl3.enabled = true;
        }
    }

    private void Lvl2Opgave2Active (bool n)
    {
        Lvl2Opgave2Falsk.SetActive(n);  
        Lvl2Opgave2Falsk2.SetActive(n); 
        Lvl2Opgave2Rigtig.SetActive(n); 
    }

    private void Lvl2Opgave3Active (bool n)
    {
        Lvl2Opgave3Rigtig.SetActive(n);
        Lvl2Opgave3Falsk.SetActive(n);
        Lvl2Opgave3Falsk2.SetActive(n);
    }


}
