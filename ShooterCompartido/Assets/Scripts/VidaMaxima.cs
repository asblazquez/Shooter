using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMaxima : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bala")
        {
            playerStats.recuperarVidaMax = true;
            Destroy(objeto);
        }
    }
}
