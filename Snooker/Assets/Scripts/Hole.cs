using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    public GameObject GM;

	// Use this for initialization
	void Start () {
        GM = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


        if(other.CompareTag("WhiteBall"))
        {
            other.gameObject.SetActive(false);
            GM.GetComponent<GameManager>().isHit = false;
            GM.GetComponent<GameManager>().isOrigin = true;
        }
        else
        {
            
            
            if (other.CompareTag("RedBall"))
            {
                GM.GetComponent<GameManager>().score = 1;
                other.gameObject.SetActive(false);
            }
            if (other.CompareTag("YellowBall"))
            {
                GM.GetComponent<GameManager>().score = 2;
                other.gameObject.SetActive(false);
            }
            if (other.CompareTag("GreenBall"))
            {
                GM.GetComponent<GameManager>().score = 3;
                other.gameObject.SetActive(false);
            }
            if (other.CompareTag("BrownBall"))
            {
                GM.GetComponent<GameManager>().score = 4;
                other.gameObject.SetActive(false);
            }
            if (other.CompareTag("BlueBall"))
            {
                GM.GetComponent<GameManager>().score = 5;
                other.gameObject.SetActive(false);
            }
            if (other.CompareTag("PinkBall"))
            {
                GM.GetComponent<GameManager>().score = 6;
                other.gameObject.SetActive(false);
            }
            if (other.CompareTag("BlackBall"))
            {
                GM.GetComponent<GameManager>().score = 7;
                other.gameObject.SetActive(false);
            }
            GM.GetComponent<GameManager>().isInHole = true;

        }
        
        
    }
}
