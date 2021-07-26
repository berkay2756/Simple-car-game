using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarVelocity : MonoBehaviour
{
    public Rigidbody carRB;
    float carSpeed;
    public Text speedText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = (int)carRB.velocity.magnitude;
        speedText.text = carSpeed.ToString() + " km/h";
    }
}
