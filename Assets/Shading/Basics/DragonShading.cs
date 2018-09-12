using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShading : MonoBehaviour
{
	private GameObject[] _customLights;
	// Use this for initialization
	void Start ()
	{
		_customLights = GameObject.FindGameObjectsWithTag("MyBasicLight");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.SetVector("_LightPos", _customLights[0].transform.position);
	}
}
