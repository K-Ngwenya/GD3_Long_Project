using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] protected GameObject cam1;
    [SerializeField] protected GameObject cam2;
    public CharacterController controller;
    private bool inRoom = false;
    public float speed = 25f;
    public Transform cam;
    public float turnSmooth = 0.1f;
    private float turnSmoothSpeed;

    private void Start()
    {
        Cursor.visible = false;
    }
    

    void Update()
    {
        if(inRoom == true)
        {
            
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSpeed, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter()
    {
        inRoom = true;
    }
}
