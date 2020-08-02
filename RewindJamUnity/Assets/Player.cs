using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float sensitivity = 0.1f;
    public int maxThrottle = 10;
    public float smoothMov = 0.5f;
    public float smoothTurning = 2f;
    float leftThrottleValue = 0f;
    float rightThrottleValue = 0f;
    Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();    
    }

    private void FixedUpdate() {
        leftThrottleValue += Input.GetAxis("VerticalLeft") * sensitivity;
        leftThrottleValue = (leftThrottleValue > maxThrottle) ? maxThrottle : leftThrottleValue;
        float roundedLeftThrottle = Mathf.Round(leftThrottleValue);
        if(Mathf.Abs(roundedLeftThrottle - leftThrottleValue) < 0.02f)
        {
            leftThrottleValue = roundedLeftThrottle;
        }
        else if(roundedLeftThrottle > leftThrottleValue)
        {
            leftThrottleValue += 0.01f;
        }
        else if(roundedLeftThrottle < leftThrottleValue)
        {
            leftThrottleValue -= 0.01f;
        }

        rightThrottleValue += Input.GetAxis("VerticalRight") * sensitivity;
        rightThrottleValue = (rightThrottleValue > maxThrottle) ? maxThrottle : rightThrottleValue;
        float roundedRightThrottle = Mathf.Round(rightThrottleValue);
        if(Mathf.Abs(roundedRightThrottle - rightThrottleValue) < 0.02f)
        {
            rightThrottleValue = roundedRightThrottle;
        }
        else if(roundedRightThrottle > rightThrottleValue)
        {
            rightThrottleValue += 0.01f;
        }
        else if(roundedRightThrottle < rightThrottleValue)
        {
            rightThrottleValue -= 0.01f;
        }

        //move the tank
        Vector3 movement = transform.forward * ((leftThrottleValue + rightThrottleValue)/2f) * smoothMov * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position+movement);

        //turn the tank
        float turn = (leftThrottleValue - rightThrottleValue) * smoothTurning * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }
}
