using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlukLyset : MonoBehaviour
{

    public Material Surroundings, DarkSurroundings;

    public Light WhiteLight1, WhiteLight2, RedLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sluk Lyset")
        {
            DynamicGI.SetEmissive(GetComponent<Renderer>(), DarkSurroundings.color);

            Surroundings.EnableKeyword("_EMISSION");
            Surroundings.SetColor("_EmissionColor", Color.black);
            // 64 on all RGB. do color.black*64 to try to revert back to original color (multiplying the intensity)
        }
        else if (other.gameObject.name == "Hvid lys 1")
        {
            WhiteLight1.enabled=true;
        }
        else if (other.gameObject.name == "Hvid lys 2")
        {
            WhiteLight2.enabled = true;
        }
        else if (other.gameObject.name == "Rødt lys")
        {
            RedLight.enabled = true;
            Surroundings.SetColor("_EmissionColor", Color.black*64 );
        }
    }
}
