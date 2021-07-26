using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform car;
    public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = car.transform.position + offset;
        // transform.LookAt(car.transform.position);
        // transform.eulerAngles = car.transform.eulerAngles;
    }
}
