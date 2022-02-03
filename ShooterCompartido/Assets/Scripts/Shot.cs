using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint;
    public PlayerMovement playerMovement;

    public float shotForce = 1500;
    public float shotRateNormal = 0.3f;
    private float shotRateTime = 0;

    public bool boostDobleTiro = false;
    private float shotRateBoost = 0.1f;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.mousePressed)
        {
            if (Time.time > shotRateTime)
            {
                GameObject newbullet;
                newbullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                if (boostDobleTiro)
                {
                    newbullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                    shotRateTime = Time.time + shotRateBoost;
                }
                else
                {
                    newbullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                    shotRateTime = Time.time + shotRateNormal;
                }
                

                Destroy(newbullet, 2);
            }
        }

        if (boostDobleTiro)
        {
            time += Time.deltaTime;
            playerMovement.dobleTiro.enabled = true;
            if (time >= 10)
            {
                playerMovement.dobleTiro.enabled = false;
                boostDobleTiro = false;
            }
        }

    }
}
