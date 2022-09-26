using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationBehavior : MonoBehaviour
{
    [SerializeField] float sensorLength = 1f;
    private Collider myCollider;
    private float distFromFriendx;
    private float distFromFriendy;


    private void Start() {
        
        LayerMask = otherGuy = LayerMask.GetMask("Obstacle");
        myCollider = transform.GetComponent<Collider>();
    }

    private void Update() 
    {
        
    }

    private void FixedUpdate() {
        
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            else if(hit.collider.tag == "otherGuy")
            {
                distFromFriendx = hit.distance;
            }
            else
            {
                sensorLength += 1f;
            }
        }



        if(Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            else if(hit.collider.tag == "otherGuy")
            {
                distFromFriendx = hit.distance;
            }
            else
            {
                sensorLength += 1f;
            }
        }

        if(Physics.Raycast(transform.position, -transform.forward, out hit, (sensorLength + transform.localScale.x)))
        {
            if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            else if(hit.collider.tag == "otherGuy")
            {
                distFromFriendz = hit.distance;
            }
            else
            {
                sensorLength += 1f;
            }
        }

        if(Physics.Raycast(transform.position, -transform.forward, out hit, (sensorLength + transform.localScale.x)))
        {
            if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
            {
                return;
            }
            else if(hit.collider.tag == "otherGuy")
            {
                distFromFriendz = hit.distance;
            }
            else
            {
                sensorLength += 1f;
            }
        }


        void RightFriend()
        {

        }

        void LeftFriend()
        {

        }

        void FrontFriend()
    }



    private void OnDrawGizmos() 
    {
       /* //Front Sensor
        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.lossyScale.z));
        //Back Sensor
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.lossyScale.z));
        //Right Sensor
        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.lossyScale.x));
        //Left Sensor
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.lossyScale.x));
        */
    }
}
