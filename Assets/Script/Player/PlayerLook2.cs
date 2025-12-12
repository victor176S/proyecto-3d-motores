using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook2 : MonoBehaviour
{

    private Vector2 rotateInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 3f, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -3f, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.GetChild(0).Rotate(2f, 0f, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.GetChild(0).Rotate(-2f, 0f, 0);
        }

        if(Input.mousePositionDelta.x > 0)
        {
            transform.Rotate(0f, Input.mousePositionDelta.x *2, 0);
        }

        if(Input.mousePositionDelta.x < 0)
        {
            transform.Rotate(0f, Input.mousePositionDelta.x *2, 0);
        }

    }

    void OnLook(InputValue value)
    {
        
        rotateInput = value.Get<Vector2>();

    }
}
