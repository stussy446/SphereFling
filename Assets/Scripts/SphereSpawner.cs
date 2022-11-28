using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SphereSpawner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private Transform _mouseTarget;
    [SerializeField] private float _maxVelocity;

    private Vector3 lastDragPosition;
    private GameObject _spawnedSphere;

    // Update is called once per frame
    void Update()
    {
        // sets up the mouseTarget to follow the cursor since the interfaces need an object to collect eventData
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 formattedMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        _mouseTarget.position = formattedMousePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // keeps track of the distance between where the mouse was last frame vs this frame, updates as long as object is still being dragged
        lastDragPosition = _mouseTarget.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        _spawnedSphere = Instantiate(_spherePrefab, _mouseTarget.position, Quaternion.identity);
        
    }

    public void OnPointerDown(PointerEventData eventData) { return; }
}
