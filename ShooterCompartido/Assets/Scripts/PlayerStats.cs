using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public float vida = 100;
    public GameObject jugador;
    public RawImage muerte;
    public float tiempoEnAire = 0f;
    public bool enAire = false;
    public PlayerMovement playerMovement;
    public bool recuperarVida = false;
    public bool recuperarVidaMax = false;
    public bool aumentarVida = false;
    public bool invisibilidad = false;
    public float tiempoInvisible = 0f;
    public bool damageMultiplier = false;
    public float tiempoDamageMultiplier = 0f;
    // Start is called before the first frame update
    void Start()
    {
        muerte.enabled = false;
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            muerte.enabled = true;
            Destroy(jugador);
        }
        if (vida <= 0)
        {
            muerte.enabled = true;
            Application.Quit();
        }

        if (enAire)
        {
            tiempoEnAire += Time.deltaTime;
        }

        if (recuperarVida)
        {
            vida = vida + 25;
            if (vida > 100)
            {
                vida = 100;
            }
            recuperarVida = false;
        }

        if (recuperarVidaMax)
        {
            vida = 100;
            recuperarVida = false;
        }

        if (aumentarVida)
        {
            vida = 150;
            aumentarVida = false;
        }
        if (invisibilidad)
        {
            tiempoInvisible += Time.deltaTime;
        }

        if (damageMultiplier)
        {
            tiempoDamageMultiplier += Time.deltaTime;
        }

        if (tiempoInvisible >= 10)
        {
            invisibilidad = false;
            tiempoInvisible = 0;
        }
        if (tiempoDamageMultiplier >= 10)
        {
            invisibilidad = false;
            tiempoInvisible = 0;
        }

    }

    void OnCollisionExit(Collision other)
    {
        // Hemos puesto un tag "Ground" sobre el suelo
        if (other.gameObject.CompareTag("Suelo"))
        {
            enAire = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Hemos puesto un tag "Ground" sobre el suelo
        if (other.gameObject.CompareTag("Suelo"))
        {
            enAire = false;
            if (tiempoEnAire >=3 && tiempoEnAire <4 && playerMovement.boostJump == false)
            {
                vida = vida - 25;
            }
            else if(tiempoEnAire >= 4 && tiempoEnAire < 5 && playerMovement.boostJump == false)
            {
                vida = vida - 50;
            }
            else if (tiempoEnAire >= 5 && tiempoEnAire < 6 && playerMovement.boostJump == false)
            {
                vida = vida - 100;
            }
            tiempoEnAire = 0;
        }
    }
}
