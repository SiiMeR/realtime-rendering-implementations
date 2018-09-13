using UnityEngine;

public class MyLight : MonoBehaviour
{

	[SerializeField] private Color _color;

	public Color Color
	{
		get => _color;
		set => _color = value;
	}

	private void Update()
	{
		GetComponent<MeshRenderer>().material.color = _color;
	}

}
