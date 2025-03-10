using System;
using UnityEngine;

public class GravityA : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.00674f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //aa
    }

    void Attract(GravityA other)
    {
        Rigidbody rbOther = GetComponent<Rigidbody>();

        Vector3 direction = rb.position - other.rb.position;

        float distance = direction.magnitude;

        if (distance == 0) { return;}
        
        float forceMagnitude = G * (rb.mass * other.rb.mass)/Mathf.Pow(distance,2);
        Vector3 force = forceMagnitude * direction.normalized;
    }
}
