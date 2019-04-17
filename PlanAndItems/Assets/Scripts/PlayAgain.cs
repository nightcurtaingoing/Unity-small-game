using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour {

    public GameObject plane;
    public GameObject Gameover;




    public void Click_test()
    {
        plane.GetComponent<Plane>().time = 60;
        plane.GetComponent<Plane>().turn = true;
        Gameover.SetActive(false);
    }
}
