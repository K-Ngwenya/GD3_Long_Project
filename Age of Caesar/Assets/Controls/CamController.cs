using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Editor
{

    public class CamController : MonoBehaviour
    {
        [SerializeField] protected GameObject cam1;
     

        private void Awake()
        {
            foreach (GameObject wall in GameObject.FindGameObjectsWithTag("Finish"))
            {
                Renderer rend;
                rend = wall.GetComponent<Renderer>();
                rend.enabled = false;
            }
        }
        

        private void OnTriggerEnter(Collider obj)
        {
            cam1.GetComponent<CinemachineFreeLook>().Priority -= 100;
            foreach(GameObject wall in GameObject.FindGameObjectsWithTag("Finish"))
            {
                Renderer rend;
                rend = wall.GetComponent<Renderer>();
                rend.enabled = true;
            }
        }

        private void OnTriggerExit(Collider obj)
        {
            cam1.GetComponent<CinemachineFreeLook>().Priority += 100;
            foreach (GameObject wall in GameObject.FindGameObjectsWithTag("Finish"))
            {
                Renderer rend;
                rend = wall.GetComponent<Renderer>();
                rend.enabled = false;
            }
        }
    }
}

