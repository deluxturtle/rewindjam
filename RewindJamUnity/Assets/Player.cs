using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    
    NavMeshAgent agent;
    Vector3 origin = Vector3.zero;
    float test;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = origin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
