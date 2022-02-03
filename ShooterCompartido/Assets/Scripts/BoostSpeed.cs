using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    public PlayerMovement boostSpeed;
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
            boostSpeed.boostSpeed = true;
            Destroy(objeto);
        }
    }
}

