using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [Header("Referencias")]

    public Transform cameraTransform;

    [Header("Mirar raton")]

    public float mouseSensitivity = 120f;

    public float minPitch = -40f;

    public float maxPitch = 40f;

    private Vector2 lookInput;

    private float cameraPitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
