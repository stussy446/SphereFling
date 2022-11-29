using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Material _sphereMaterial;
    private void Start()
    {
        _sphereMaterial = GetComponent<Renderer>().material;

        _sphereMaterial.SetColor("_FresnelColor", GenerateRandomColor());
        _sphereMaterial.SetColor("_BaseColor", GenerateRandomColor());
    }

    private Color GenerateRandomColor()
    {
        Color randomColor = new Color(
        Random.Range(0.1f, 1f),
        Random.Range(0.1f, 1f),
        Random.Range(0.1f, 1f)
        );

        return randomColor;
    }
}