using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{

    [Header("Cámaras")]

    [Tooltip("si se deja vacio, se buscaran automaticamente las camaras hijas")]

    [SerializeField] private List<Camera> cameras = new List<Camera>();

   [SerializeField]  private int currentCamera = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (cameras == null || cameras.Count == 0)
        {
            cameras = new List<Camera>(GetComponentsInChildren<Camera>());
        }

        SetActiveCamera(currentCamera);
    }

    private void SetActiveCamera(int index)
    {

        Debug.Log(index);

        for (int i = 0; i < cameras.Count; i++)
        {
            bool isActive = i == index;

            if (cameras[i] != null)
            {
                cameras[i].enabled = isActive;
            }
        }
    }

    public void OnChangeCamera(InputValue value)
    {

        Debug.Log("CameraInput");
        
        if (cameras == null || cameras.Count == 0)
        {
            return;
        }

        currentCamera++;

        if (currentCamera >= cameras.Count)
        {
            currentCamera = 0;

        }

         SetActiveCamera(currentCamera);

    }
}
