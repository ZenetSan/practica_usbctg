using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_npc : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocityInitial;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 20.0f;
    public float horizontal = 1f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {   
        if(GameManager.activado == false) return;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {   
            horizontal = horizontal*-1;
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(horizontal, 0, /*Input.GetAxis("Vertical")*/0);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}