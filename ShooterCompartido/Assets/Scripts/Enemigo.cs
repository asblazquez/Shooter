using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    public float vida = 100;
    public bool hit = false;
    public GameObject objeto;
    public GameObject jugador;
    public Transform posEnemigo;
    public bool deteccion = false;
    public PlayerStats playerStats;
    public float damage = 35;
    public NavMeshAgent navMeshAgent;
    public GameObject objetivo;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bala")
        {
            if (playerStats.damageMultiplier)
            {
                hit = true;
                vida = vida - (damage * 2);
            }
            else
            {
                hit = true;
                vida = vida - damage;
            }
            
        }

        if (other.tag == "Jugador")
        {
            playerStats.vida = playerStats.vida - 50;
        }
    }

    private void Update()
    {
        if (vida <= 0)
        {
            Destroy(objeto);
        }
        if (deteccion && !playerStats.invisibilidad)
        {
            navMeshAgent.destination = jugador.transform.position;
        }

        navMeshAgent.destination = objetivo.transform.position;
    }
}
