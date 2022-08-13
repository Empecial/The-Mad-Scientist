using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opgaver : MonoBehaviour
{
    // Denne kode var lavet med hjælp fra denne video "https://docs.unity3d.com/ScriptReference/".

    public GameObject Opgave1, Opgave2, Opgave3, OpgaveDone, OpgaveCheck;

    public BoxCollider ColLvl1LaptopMolarMasse, ColLvl1LaptopCO2; //ColLvl2LaptopRigtig, ColLvl2LaptopFalsk1, ColLvl2LaptopFalsk2;

    GameObject LaptopMolarFalsk1, LaptopMolarFalsk2, LaptopMolarKorrekt, LaptopCO2, LaptopSalt, LaptopXenon, Ag, Mg, Au;


    private void Start()
    {
        // Vi kalder på class'en ""LoadGameObject" for at få de forskellige GameObject's defineret.
        LoadGameObject();
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //Opgave 1
        // Vi kalder på class'en "Opgave" for at udføre opgaven.

        Opgave(GameObject.Find("Ag"));

        //Opgave 2
        // Vi kalder på class'en "Opgave" for at udføre opgaven.

        Opgave(GameObject.Find("Laptop - Molar"));

        //Denne del er en del af opgave 2.
        if (this.gameObject.name == "Masse Formel")
        {
            OpgaveCheck.GetComponent<OpgaveCheck>().Opgave2Ekstra = true;
        }

        // Opgave 3
        // Vi kalder på class'en "Opgave" for at udføre opgaven.

        Opgave(GameObject.Find("Laptop - CO2"));
    }


    public void Opgave(GameObject GB)
    {
        // Opgave 1
        // Vi anvender den nævnte GameObject GB og sætter class'en til at spørge om den hedder "Ag". Vi anvender et andet skript, som en form for opbevaringskilde
        // til de forskellige booleans som vi bruger over flere objekter. Vi "fjerner" kolberne og for molar opgaven klar til at den kan opklares.

        if (GB.name == "Ag")
        {
            if (OpgaveCheck.GetComponent<OpgaveCheck>().OPG1Lavet == false)
            {
                if (gameObject.CompareTag(GB.name))
                {
                    OpgaveCheck.GetComponent<OpgaveCheck>().OPG1Lavet = true;
                    Opgave2.SetActive(true);
                    LaptopMolarMeshRend(true);
                    ColLvl1LaptopMolarMasse.enabled = true;
                    KolbeAg(false);
                    Debug.Log("level1");
                }
            }
        }

        // Opgave 2
        // Vi anvender den nævnte GameObject GB og sætter class'en til at spørge om den hedder "Laptop - Molar". Vi anvender et andet skript, som en form for opbevaringskilde
        // til de forskellige booleans som vi bruger over flere objekter. 

        else if (GB.name == "Laptop - Molar")
        {
            if (OpgaveCheck.GetComponent<OpgaveCheck>().OPG1Lavet == true && OpgaveCheck.GetComponent<OpgaveCheck>().OPG2Lavet == false)
            {

                /* af en uvidet grund vil dette stykke ikke køre. 
                 påstand om at det er gameobject.CompareTag(GB.name) 
                der forårsager fejlen */
                if (gameObject.CompareTag(GB.name))
                {
                    OpgaveCheck.GetComponent<OpgaveCheck>().OPG2Lavet = true;
                    Opgave3.SetActive(true);
                    ColLvl1LaptopCO2.enabled = true;
                    LaptopCO2MeshRend(true);
                    Debug.Log("level2");
                }
            }
        }

        // Opgave 3
        // Vi anvender den nævnte GameObject GB og sætter class'en til at spørge om den hedder "Laptop - CO2". Vi anvender et andet skript, som en form for opbevaringskilde
        // til de forskellige booleans som vi bruger over flere objekter.

        else if (GB.name == "Laptop - CO2")
        {
            if (OpgaveCheck.GetComponent<OpgaveCheck>().OPG2Lavet == true && OpgaveCheck.GetComponent<OpgaveCheck>().OPG3Lavet == false)
            {
                if (gameObject.CompareTag(GB.name))
                {
                    OpgaveCheck.GetComponent<OpgaveCheck>().OPG3Lavet = true;
                    OpgaveDone.SetActive(true);
                    Debug.Log("level3");
                }
            }
        }
    }
    // Load sektion

    // Denne class bruges til at lave en mere overskuelig og mere læselig skript. Class'en bliver kaldt når at spillet starter. Vi anvender GameObject.Find da vi mener
    // at der vil blive en for stor overskuelighed i forhold til hvor mange GameObjects der skal defineres, når scriptet bliver sat på et nyt objekt.

    private void LoadGameObject()
    {
        LaptopMolarFalsk1 = GameObject.Find("Laptop - Masse udregning (falsk 1) tekst");
        LaptopMolarFalsk2 = GameObject.Find("Laptop - Masse udregning (falsk 2) tekst");
        LaptopMolarKorrekt = GameObject.Find("Laptop - Masse udregning (korrekt) tekst");
        LaptopCO2 = GameObject.Find("Laptop - CO2 Tekst");
        LaptopSalt = GameObject.Find("Laptop - Salt tekst");
        LaptopXenon = GameObject.Find("Laptop - Xenon tekst");
        Ag = GameObject.Find("Ag");
        Mg = GameObject.Find("Mg");
        Au = GameObject.Find("Au");
    }


    // Aktiverings sektion

    // Disse classes er lavet til at kunne både gøre sådan at man kan se de forskellige valg muligheder i laboratoriet til opgave 2 og 3, dette gøres ved hjælp af booleans.

    private void LaptopMolarMeshRend(bool n)
    {
        LaptopMolarFalsk1.GetComponent<MeshRenderer>().enabled = n;  
        LaptopMolarFalsk2.GetComponent<MeshRenderer>().enabled = n;
        LaptopMolarKorrekt.GetComponent<MeshRenderer>().enabled = n;
    }

    private void LaptopCO2MeshRend(bool n)
    {
        LaptopCO2.GetComponent<MeshRenderer>().enabled = n;
        LaptopSalt.GetComponent<MeshRenderer>().enabled = n;
        LaptopXenon.GetComponent<MeshRenderer>().enabled = n;
    }
    

    // Denne metode er lavet til at kunne både gøre sådan at man kan se kolberne i laboratoriet, dette gøres ved hjælp af booleans.

     private void KolbeAg(bool n)
    {
        Ag.GetComponent<MeshRenderer>().enabled = n;
        Mg.GetComponent<MeshRenderer>().enabled = n;
        Au.GetComponent<MeshRenderer>().enabled = n;
    } 
    
} 
