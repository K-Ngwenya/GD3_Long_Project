using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    public GameObject target;
    public GameObject unit;
    public float speed = 0.2f;


    private void Update() {
        float distance = Vector3.Distance(target.transform.position, unit.transform.position);

        transform.LookAt(target.gameObject.transform);
        if(distance >= 1f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
