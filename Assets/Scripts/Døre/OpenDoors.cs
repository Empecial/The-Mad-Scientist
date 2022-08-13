using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    
    [SerializeField] Animator openAnimDoor1,openAnimDoor2, openSecretDoor, OpenSecretDoor2;

    [SerializeField] GameObject Button1,Button2;

    public GameObject SecretDoorTriggerEnter, SecretDoorTriggerExit;

    // for at stoppe spilleren fra at spille lyden hele tiden
    [SerializeField] bool AlreadyPlayed1, AlreadyPlayed2, SecretDoor1open, SecretDoor2open = false;

    public void Start()
    {
        //AudioSource DoorOpening = GameObject.FindGameObjectWithTag("Player").GetComponent<MusicAndSounds>().DørÅbningsLyde;
    }

    private void OnTriggerEnter(Collider other)
    {
        // finder lyden for dør åbningen
        AudioSource DoorOpening = GameObject.FindGameObjectWithTag("Player").GetComponent<MusicAndSounds>().DørÅbningsLyde;

        // for when players enter the trigger of the buttons the door animations play
        if (other.CompareTag("Button1") && !AlreadyPlayed1)
        {
            openAnimDoor1.SetBool("OpenDoor1", true);
            DoorOpening.Play();
            AlreadyPlayed1 = true;
        }
        
        if (other.CompareTag("Button2"))
        {
            openAnimDoor2.SetBool("OpenDoor2",true);
            DoorOpening.Play();
        }
        
        if (other.gameObject.CompareTag("SecretDoorTriggerEnter") && !SecretDoor1open)
        {
            openSecretDoor.SetBool("SecretDoorOpen", true);
            DoorOpening.Play();
            SecretDoor1open = true;
        }
        else
        {
            openSecretDoor.SetBool("SecretDoorOpen", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //for Button1 on exit with the button trigger
        if (other.CompareTag("Button1"))
        {
            openAnimDoor1.SetBool("OpenDoor1", false);
        }
        else if (other.CompareTag("Button2"))
        {
            openAnimDoor2.SetBool("OpenDoor2",false);
        }
    }

}
