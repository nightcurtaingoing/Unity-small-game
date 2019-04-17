using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public GameObject ItemsPar;
    public float DestroyDeep = -50;
	// Use this for initialization
	void Start () {
        ItemsPar = GameObject.FindGameObjectWithTag("ItemPar");
        this.transform.SetParent(ItemsPar.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y <= DestroyDeep)
        {
            Destroy(this.gameObject);
        }
	}
}
