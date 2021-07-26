using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public Text secretText;
    public float timeLeft;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "iWall")
        {
            timeLeft = 5f;
            Debug.Log("You hit an invisible wall!");
            secretText.enabled = true;
        }
    }

    void LateUpdate()
    {
        if (secretText.enabled == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                secretText.enabled = false;
            }
        }
    }
}
