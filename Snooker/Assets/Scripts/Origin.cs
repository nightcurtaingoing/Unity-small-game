using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour {

    public bool isInD;

	// Use this for initialization
	void Start () {
        isInD = false;
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WhiteBall"))
        {
            isInD = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("WhiteBall"))
        {
            isInD = false;
        }
        
    }

}
