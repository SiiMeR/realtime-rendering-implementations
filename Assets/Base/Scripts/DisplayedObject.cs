using UnityEngine;

public class DisplayedObject : MonoBehaviour
{

	[Header("Movement animation controls")]
	
	public bool isRotating = true;
	
	public float animationRotationSpeed = 30f;

	
	[Header("Movement animation controls")]
	
	public bool isMovingUpAndDown = true;

	public float animationAmplitude = 1f;
	public float animationPeriod = 1f;
	
	
	private Vector3 _startPos;
	
	// Use this for initialization
	void Start ()
	{
		_startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (isRotating)
		{
			transform.Rotate(Vector3.up, animationRotationSpeed * Time.deltaTime);
		}

		if (isMovingUpAndDown)
		{
			var theta = Time.timeSinceLevelLoad / animationPeriod;
			var distance = animationAmplitude * Mathf.Sin(theta);
			transform.position = _startPos + Vector3.up * distance;
		}
	}
}
