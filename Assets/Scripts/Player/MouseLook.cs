using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Denne kode blev lavet med "https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys".
    // Denne kode var lavet med hjælp fra denne video "https://docs.unity3d.com/ScriptReference/".

    // Dette er musens hastighed i spillet for hvor hurtigt man kan kigge rundt.
    public float mousesensitivity = 300f;

    // For at rotere kameraet med kroppen.
    public Transform playerbody;

    // Denne hjælper med at få karakteren til at kigge med y aksen.
    float xaxisRotate = 0f;

    void Start()
    {
        //gør musen på skærmen usynlig i selve spillet og låser den i midten af spillet.
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LateUpdate()
    {
        // Gør at musen kan kigge med x og y aksen og har time.deltatime så dens hastighed er stabil.
        float mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        // Gør at man kan kigge op og ned ved at rotere omkring x aksen.
        xaxisRotate -= mousey;

        // Låser rotationen, så man ikke kan rotere så meget at man kan kigge bag sig.
        xaxisRotate = Mathf.Clamp(xaxisRotate, -90f, 90f);

        // For at rotere og holder x aksen i tjek.
        transform.localRotation = Quaternion.Euler(xaxisRotate, 0f, 0f);

        // For at rotere kameraet omkring playerbody på x aksen.
        playerbody.Rotate(Vector3.up * mousex);
    }
}
