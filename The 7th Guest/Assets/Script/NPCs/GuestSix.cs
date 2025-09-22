using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestSix : MonoBehaviour
{
    [SerializeField] private Neighbor neighbor;
    [SerializeField] private GamaManager gm;

    [SerializeField] private Snap snap;
    [SerializeField] private Drag self;

    [SerializeField] private Drag hatedPerson;

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
        if (neighbor.leftNeighbor != null && neighbor.rightNeighbor != null)
        {
            neighbor.satisfication += 0.1f;
        }
        else
        {
            neighbor.satisfication -= 0.1f;
        }
        if (neighbor.leftNeighbor == hatedPerson || neighbor.rightNeighbor == hatedPerson)
        {
            neighbor.satisfication -= 0.1f;
        }
        Debug.Log("guestsix " + neighbor.satisfication);
    }
}
