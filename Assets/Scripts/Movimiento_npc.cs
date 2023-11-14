using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_npc : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float gravityValue = -9.81f;
    public float playerSpeed = 20.0f;
    public float horizontal = 1f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {   
        if(GameManager.activado == false) return;

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out hit, 1))
        {
            if(hit.collider.CompareTag("Player")){
                controller.enabled = false;
                transform.position = new Vector3(0, 0, 0);
            }
        }

        Vector3 promedio = new Vector3(0,0,0);
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {   
            gravityValue = -9.81f;
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(horizontal, 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        promedio.y = playerVelocity.y + (playerVelocity.y + gravityValue * Time.deltaTime) ;
        
        controller.Move(promedio * Time.deltaTime);

        if(transform.position.y <= -5){
            controller.enabled = false;
            transform.position = new Vector3(0, 0, 0);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag != "suelo"){
            horizontal = horizontal*-1;
        }
    }
}