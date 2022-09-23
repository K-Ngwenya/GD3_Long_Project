using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Controls controller;
    CharacterController thePlayer;
    private Vector2 moveInput;
    
    private float speed = 5f;
    private float velocity;

    private void Awake() {
        controller = new Controls();
        thePlayer = GetComponent<CharacterController>();
        
    }

    private void FixedUpdate() {
        moveInput = controller.Player.Move.ReadValue<Vector2>();
        Vector3 horizontalVelocity = new Vector3(moveInput.x, 0, moveInput.y);
        thePlayer.Move(horizontalVelocity * Time.deltaTime * speed);
        Debug.Log(moveInput);

        
    }
}
