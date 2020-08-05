using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public float speeed = 5f;
    float horizontal;
    float vertical;
    Rigidbody rigidbody;
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        

    }

    private void FixedUpdate() {
        Vector3 targetDir = new Vector3(horizontal, 0, vertical);
        
        transform.position += targetDir * speeed * Time.deltaTime;
    }

}
