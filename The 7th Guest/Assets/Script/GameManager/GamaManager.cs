using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamaManager : MonoBehaviour
{
    [SerializeField] private GameObject theMansion;
    [SerializeField] private GameObject livingRoom;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            theMansion.SetActive(false);
            livingRoom.SetActive(true);
        }
    }
}
