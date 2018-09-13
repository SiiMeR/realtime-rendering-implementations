using UnityEngine;

public class Chopper : MonoBehaviour
{

	public GameObject rotor;
	public GameObject[] wings;
	
	// Update is called once per frame
	void Update ()
	{	
		rotor.transform.Rotate(Vector3.up, 20f * Time.deltaTime);
	}
}
