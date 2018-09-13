using UnityEngine;

[ExecuteInEditMode]
public class DragonShading : MonoBehaviour
{
    private MyLight[] _customLights;

    private Matrix4x4[] _customLightMatrix;

    private Renderer _renderer;
    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        
        _customLights = FindObjectsOfType<MyLight>();
        _customLightMatrix = new Matrix4x4[_customLights.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
        for (var i = 0; i < _customLights.Length; i++)
        {
            _customLightMatrix[i].SetRow(0, _customLights[i].transform.position);
            _customLightMatrix[i].SetRow(1, _customLights[i].Color);
        }
        
        _renderer.sharedMaterial.SetInt("_lightCount", _customLights.Length);
        _renderer.sharedMaterial.SetMatrixArray("_lights", _customLightMatrix);
        
    }
}