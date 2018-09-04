using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopper : MonoBehaviour
{

	public GameObject rotor;
	public GameObject[] wings;
	

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update ()
	{	
		rotor.transform.Rotate(Vector3.up, 20f * Time.deltaTime);
	}
}
