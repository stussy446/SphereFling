using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Renderer _sphereRenderer;
    private void Start()
    {
        _sphereRenderer = GetComponent<Renderer>();

        Color fresnalColor = new Color(
        Random.Range(0.1f, 1f),
        Random.Range(0.1f, 1f),
        Random.Range(0.1f, 1f)
        );

        _sphereRenderer.material.SetColor("_FresnelColor", GenerateRandomColor());
        _sphereRenderer.material.SetColor("_BaseColor", GenerateRandomColor());

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