using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GamaManager : MonoBehaviour
{
    public static event Action OnCheck;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnCheck != null)
            {
                OnCheck.Invoke();
            }
        }
    }
}
