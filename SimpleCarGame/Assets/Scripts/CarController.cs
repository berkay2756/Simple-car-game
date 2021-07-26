using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public float carThr = 20f;
    public float force;

    public GameObject frontLeftWheel;
    public GameObject frontRightWheel;
    public GameObject backLeftWheel;
    public GameObject backRightWheel;
    public GameObject CAR;
    private float forwardInput;
    public float horizontalInput;
    private float turnSpeed = 90f;
    private float rotationSpeed = 4000f;
    Vector3 minRotation;
    Vector3 maxRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene01"));
        carRigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, Physics.gravity.y * 5f, 0); // gravity value
    }  // 140,230

    // Update is called once per frame
    void FixedUpdate()
    {
        minRotation = new Vector3(0f, 140f, 0f);
        maxRotation = new Vector3(0f, 230f, 0f);

        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        mainMovement();
        spinWheels();
        turnWheels();

    }

    void mainMovement()
    {
        // Apply a force to this Rigidbody in direction of this GameObjects up axis
        carRigidbody.AddForce(transform.forward * carThr * forwardInput);

        force = carThr * forwardInput;

        if (forwardInput > 0 && force == carThr)
        {
            transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
        }

        if (forwardInput < 0 && force == -carThr)
        {
            transform.Rotate(Vector3.up * -horizontalInput * Time.deltaTime * turnSpeed);
        }

        if (transform.rotation.x != 0 && Input.GetKey("r") && transform.rotation.z != 0 && CAR.transform.position.y > 0.515507f)
        {
            CAR.transform.eulerAngles = new Vector3(0, CAR.transform.eulerAngles.y, 0);
            transform.position = transform.position + new Vector3(0, -transform.position.y + 0.515507f, 0);
            Debug.Log("Reset key pressed.");
        }
    }

    void spinWheels()
    {
        // wheels rotating around the x axis
        frontLeftWheel.transform.Rotate(Vector3.right * forwardInput * Time.deltaTime * rotationSpeed * force * 0.005f);
        frontRightWheel.transform.Rotate(Vector3.right * forwardInput * Time.deltaTime * rotationSpeed * force * 0.005f);
        backLeftWheel.transform.Rotate(Vector3.right * forwardInput * Time.deltaTime * rotationSpeed * force * 0.005f);
        backRightWheel.transform.Rotate(Vector3.right * forwardInput * Time.deltaTime * rotationSpeed * force * 0.005f);
    }

    void turnWheels()
    {
        // front left wheel
        Vector3 temp;
        if (horizontalInput == 0)
        {
            temp.y = 180;
        }
        else
        {
            temp = frontLeftWheel.transform.localEulerAngles;
            temp.y = horizontalInput * 50;
            frontLeftWheel.transform.localEulerAngles = temp;
        }

        // front right wheel
        if (horizontalInput == 0)
        {
            temp.y = 0;
        }
        else
        {
            temp = frontRightWheel.transform.localEulerAngles;
            temp.y = horizontalInput * 50;
            frontRightWheel.transform.localEulerAngles = temp;
        }
    }

    }

