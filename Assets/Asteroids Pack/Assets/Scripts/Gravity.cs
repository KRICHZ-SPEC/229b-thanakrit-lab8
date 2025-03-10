using System;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.006674f;
    public static List<Gravity> otherObjectslist;
    private void FixedUpdate()
    {
        foreach (var Planet in otherObjectslist)
        {
            if (Planet != this)
                Attract(Planet);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObjectslist == null)
        {
            otherObjectslist = new List<Gravity>();
        }
        otherObjectslist.Add(this);
    }
    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 FinalForce = forceMagnitude * direction.normalized;
        
        otherRb.AddForce(FinalForce);
    }
}
