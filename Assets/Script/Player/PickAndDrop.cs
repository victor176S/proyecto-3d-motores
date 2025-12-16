using System;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickAndDrop : MonoBehaviour
{

    [Header("Mochila")]
    [SerializeField] private Transform mochila;

    [Header("Input System")]

    [Tooltip("arrastra aqui la accion 'soltar' (InputActionReference)." +
     "Si lo dejas vacio se busca por nombre em PlayerInput")]

    private InputActionReference soltarActionRef;

    [SerializeField] private string soltarActionName = "Drop";

    [Header("Drop")]

    [SerializeField] private Vector3 dropOffset = new Vector3(2f, 0f, 0f);

    private GameObject objetoEnMochila;

    private InputAction soltarAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (soltarActionRef != null)
        {
            soltarAction = soltarActionRef.action;
        }

        else
        {
            
            var playerInput = GetComponent<PlayerInput>();

            if (playerInput != null)
            {
                soltarAction = playerInput.actions.FindAction(soltarActionName, throwIfNotFound: false);
            }

        }
    }

    void OnEnable()
    {
        if (soltarAction != null)
        {
            soltarAction.performed += OnSoltarPerformed;

            soltarAction.Enable();
        }
    }

    private void OnSoltarPerformed(InputAction.CallbackContext obj) => Soltar();

    private void Soltar()
    {
        if (objetoEnMochila == null)
        {
            return;
        }
        
        objetoEnMochila.transform.SetParent(null);

        objetoEnMochila.transform.position = transform.TransformPoint(dropOffset);

        if(objetoEnMochila.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.isKinematic = false;
        }

        objetoEnMochila = null;
    }

    private void OnTriggerEnter(Collider other) => TryPick(other.gameObject);

    //private void OnCollisionEnter(Collision other) => TryPick(other.gameObject);

    private void TryPick(GameObject go)
    {
        if (objetoEnMochila != null)
        {
            return;
        }

        if (!go.CompareTag("Pick"))
        {
            return;
        }

        objetoEnMochila = go;

        //en caso de no tener RigidBody, no salta error, pero se salta esto

        if (objetoEnMochila.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.linearVelocity = Vector3.zero;

            rb.angularVelocity = Vector3.zero;

            rb.isKinematic = true;

        }

        objetoEnMochila.transform.SetParent(mochila, worldPositionStays: false);

        objetoEnMochila.transform.localPosition = Vector3.zero;

        objetoEnMochila.transform.localRotation = Quaternion.identity;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
