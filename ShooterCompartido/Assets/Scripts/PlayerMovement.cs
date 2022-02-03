using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]


public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float jumpForce = 1.0f;
    public float horizontal, vertical, rotationY;
    private Rigidbody physics;
    private bool canJump = true;
    public bool mousePressed = false;
    public Transform posJugador;
    public float dashForce = 30;
    private bool dashAviable = true;
    public GameObject jugador;

    public bool boostSpeed = false;
    public bool boostJump = false;

    public float timeBoostJump = 0;
    public float timeBoostSpeed = 0;
    public float timeDash = 0;

    private float speedBost = 20;
    private float normalSpeed = 10;
    private float jumpBost = 10;
    private float normalJump = 5;

    public RawImage boostJumpImage;
    public RawImage boostSpeedImage;
    public RawImage dobleTiro;






    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        boostJumpImage.enabled = false;
        boostSpeedImage.enabled = false;
        dobleTiro.enabled = false;

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        physics = GetComponent<Rigidbody>();
        if (physics == null)
        {
            physics = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            physics.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && dashAviable)
        {
            jugador.GetComponent<Rigidbody>().AddForce(posJugador.forward * dashForce);
            dashAviable = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePressed = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mousePressed = false;
        }

        if (boostSpeed)
        {
            boostSpeedImage.enabled = true;
            speed = speedBost;
            timeBoostSpeed += Time.deltaTime;
        }
        
        if (boostJump)
        {
            boostJumpImage.enabled = true;
            jumpForce = jumpBost;
            timeBoostJump += Time.deltaTime;
        }
        
        if (timeBoostJump >= 10)
        {
            boostJumpImage.enabled = false;
            jumpForce = normalJump;
            boostJump = false;
            timeBoostJump = 0;
        }

        
        if (timeBoostSpeed >= 10)
        {
            boostSpeedImage.enabled = false;
            speed = normalSpeed;
            boostSpeed = false;
            timeBoostSpeed = 0;
        }

        if (dashAviable == false)
        {
            timeDash += Time.deltaTime;
            if (timeDash >= 3)
            {
                dashAviable = true;
                timeDash = 0;
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        // Hemos puesto un tag "Ground" sobre el suelo
        if (other.gameObject.CompareTag("Suelo"))
        {
            canJump = true;
        }
    }
}
