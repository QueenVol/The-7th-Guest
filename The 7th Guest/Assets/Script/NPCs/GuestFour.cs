using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestFour : MonoBehaviour
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
        GamaManager.OnCheck += HostPreference;
    }

    private void OnDisable()
    {
        GamaManager.OnCheck -= HostPreference;
    }

    private void HostPreference()
    {
        if (snap.currentSnapPoint[self] == snap.snapPoints[2] || snap.currentSnapPoint[self] == snap.snapPoints[6])
        {
            neighbor.satisfication += 0.1f;
        }
        else
        {
            neighbor.satisfication -= 0.1f;
        }
        Debug.Log("guestfour " + neighbor.satisfication);
    }
}
