using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Denne kode var lavet med hjælp fra denne video "https://docs.unity3d.com/ScriptReference/".
    // Denne kode blev lavet med "https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys".


    // Dette er en charactercontroller som scriptet bruger til at holde styr på de diverse ting.
    public CharacterController controller;
    
    // Dette er hastigheden af spilleren.
    public float speed = 12f;
    
    
    void Update()
    {
        // Næste 2 linjer forklarer om hvile akser moveHorizontal og moveVerticaler.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Dette gør at når spilleren kigger en retning, så bevæger kroppen sig også i den retning.
        Vector3 move = transform.right* moveHorizontal + transform.forward * moveVertical;

        // Dette gør at spilleren kan bevæge sig og holder det stabilt så spilleren ikke bliver for hurtig.
        controller.Move(move * speed * Time.deltaTime);
    }

}
