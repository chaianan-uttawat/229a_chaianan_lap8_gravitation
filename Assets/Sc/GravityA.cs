using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityA : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.00674f;

    public static List<GravityA> gravityObjectList;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectList == null)
        {
            gravityObjectList = new List<GravityA>();
        }
        
        gravityObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        //all Attract
        foreach (GravityA obj in gravityObjectList)
        {
            Attract(obj);
        }
    }

    void Attract(GravityA other)
    {
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        if (distance == 0) { return;}
        
        float forceMagnitude = G * (rb.mass * rbOther.mass)/Mathf.Pow(distance,2);
        Vector3 force = forceMagnitude * direction.normalized;
        rbOther.AddForce(force);
    }
}
