using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpSystem : MonoBehaviour
{
    // Denne kode var lavet med hjælp fra denne video "https://docs.unity3d.com/ScriptReference/".
    // Denne kode var lavet med hjælp fra denne video "https://www.youtube.com/watch?v=IEV64CLZra8&t=1s&ab_channel=JimmyVegas". Vi prøvede en del ting før at vi så hans video.
    // Dog virkede det ikke i forhold til tyngdekraften.

    public Transform pickupPosition;
    
    // Boolean som trækker om der er et objekt som er blevet taget op.
    public bool isPickUp;

    // Collider til at føle om man går ind på et objekt, der kan samles op.
    private Collider PickupCollider;

    // Ridigbody til det objekt der bliver samlet op.
    private Rigidbody PickupGravity;

    // Booleanen for om der er et objekt der er samlet op bliver sat til at være falsk. Derudover bliver både Collider'en og Ridigbody'en sat.
     void Start()
    {
        isPickUp = false;
        PickupCollider = GetComponent<CapsuleCollider>();
        PickupGravity = GetComponent<Rigidbody>();
    }

    // Vi bruger en FixedUpdate i stedet for en Update, da vi opdagede at det ville være mindre "lagbart". Vi tjekker om spilleren vil 
    // smide objektet, som er samlet op. Derfor kalder vi på class'en DropItem for at smide objektet.
    private void FixedUpdate()
    {
        if (isPickUp == true)
        {
            if (Input.GetKeyDown(KeyCode.G) == true)
            {
                DropItem();
            }
        }
    }

    // Både Collider'en bliver sat til at være falsk, for at objektet ikke skal være besværlig i forhold til spillets miljø. 
    // Derudover bliver Ridigbody'en tyndgekraft sat til falsk. Dette gøres for at objektet ikke skal falde ned til jorden,
    // men at den forbliver der hvor den bliver transporteret til. Vi sætter også boolean'en om objektet er samlet op til at være sandt.
    void OnTriggerEnter(Collider other)
    {
        if (isPickUp == false)
        {
            PickupCollider.enabled = false;
            PickupGravity.useGravity = false;

            // Laver objektet til at være et child til spilleren.
            this.transform.position = pickupPosition.position;
            this.transform.parent = pickupPosition.transform; 
            //this.transform.parent = GameObject.Find("PickupsPosition").transform;
            Debug.Log("pickupob's Parent: " + this.transform.parent.name);

            isPickUp = true;
        }
    }

    // DropItem er en class som skal smide det objekt, som er samlet op. Dette gøres ved at få den satte parent til at være null.
    // Vi sætter objektet, lidt væk fra spilleren sådan at spilleren ikke tager objektet op lige med det samme.
    // Det var meningen i starten at vi skulle bruge vektor til at vurdere hvor spilleren kiggede henne og så derudfra sætte objektet.
    // Vi sætter også den boolean der siger om objektet er samlet op, til at være falsk.
    void DropItem()
    {
      PickupCollider.enabled = true;
        
        
        this.transform.position= (new Vector3(this.transform.position.x, this.transform.position.y-2f, this.transform.position.z));
        
        this.transform.parent = null;
        //childObject.transform.position = (new Vector3(player.transform.position.x, player.transform.position.y-0.4f, player.transform.position.z));
        
        isPickUp = false;
    }
}
