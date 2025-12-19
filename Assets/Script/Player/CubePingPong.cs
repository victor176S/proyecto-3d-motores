using System.Collections;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class CubePingPong : MonoBehaviour
{

    [Header("Puntos entre los que se moverá")]
    [SerializeField] private Transform pointA, pointB, currentTarget;
    
    [Header("Velocidad de movimiento")]

    private float velocidad = 2f;
    private GameObject Player;

    [SerializeField] private bool enSuelo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Player = GameObject.Find("Player");

        if (pointA == null || pointB == null)
        {
            Debug.LogError("puntos null");

            Destroy(this.gameObject);

            return;
        }

        transform.position = pointA.position;

        currentTarget = pointB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
        {
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
        }

        PlatformControl();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {

            enSuelo = true;

        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {

            enSuelo = false;
            
        } 
    }

    private void PlatformControl()
    {
        if (enSuelo)
        {
            Player.transform.position += new Vector3 (0, gameObject.transform.position.y - Player.transform.position.y, 0);
        }

        else
        {
            
        }
    }
}
