using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocityInitial;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 20.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {   
            gravityValue = -9.81f;
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, /*Input.GetAxis("Vertical")*/0);
        controller.Move(move * Time.deltaTime * playerSpeed);
      
        // Changes the height position of the player..
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);;
        }

        if (Input.GetButtonUp("Jump")){
            gravityValue = gravityValue * 2;
        }

        Vector3 promedio = new Vector3(0,0,0);
        promedio.y = playerVelocity.y + ( playerVelocity.y + gravityValue * Time.deltaTime) ;

        playerVelocity.y += gravityValue * Time.deltaTime;



        controller.Move(promedio * Time.deltaTime);
    }
}