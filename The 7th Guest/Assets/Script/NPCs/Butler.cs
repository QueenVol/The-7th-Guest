using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butler : MonoBehaviour
{
    [SerializeField] private Neighbor neighbor;
    [SerializeField] private GamaManager gm;

    [SerializeField] private Snap snap;
    [SerializeField] private Drag self;

    private void Start()
    {
        neighbor.satisfication = 0.5f;
    }

    private void OnEnable()
    {
        GamaManager.OnCheck += ButlerPreference;
    }

    private void OnDisable()
    {
        GamaManager.OnCheck -= ButlerPreference;
    }

    private void ButlerPreference()
    {
        if (snap.currentSnapPoint[self] != null)
        {
            neighbor.satisfication -= 0.2f;
            neighbor.satisfication = Mathf.Clamp(neighbor.satisfication, 0f, 1f);
        }
        else
        {
            neighbor.satisfication += 0.2f;
            neighbor.satisfication = Mathf.Clamp(neighbor.satisfication, 0f, 1f);
        }
        Debug.Log("butler " + neighbor.satisfication);
    }
}
