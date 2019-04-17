using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector3 Speed;
    private Rigidbody rg;
	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody>();
        Speed = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        if (rg.velocity.magnitude > 0.05)
        {
            Speed = rg.velocity;
        }
            
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
	}
}
