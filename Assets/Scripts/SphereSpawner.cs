using UnityEngine;
using UnityEngine.EventSystems;

public class SphereSpawner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private Transform _mouseTarget;
    [SerializeField] private float _speed;

    private GameObject _spawnedSphere;
    private Vector3 _formattedMousePos;
    private Vector3 _startPosition;

    void Update()
    {
        // sets up the mouseTarget to follow the cursor 
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        _formattedMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        _mouseTarget.position = _formattedMousePos;
    }

    /// <summary>
    /// Stores the starting position of the mouse when the mousebutton is first held down
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        _startPosition = _formattedMousePos;
    }

    /// <summary>
    /// When the mouse button is released, instantiates a sphere at that position and adds an impulse force on the sphere based on the direction of the mouse movement
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        _spawnedSphere = Instantiate(_spherePrefab, _mouseTarget.position, Quaternion.identity);
        Rigidbody sphereRb = _spawnedSphere.GetComponent <Rigidbody>();

        Vector3 force = transform.position - _startPosition;
        force.Normalize();

        sphereRb.AddForce(force * _speed, ForceMode.Impulse);
    }

}
