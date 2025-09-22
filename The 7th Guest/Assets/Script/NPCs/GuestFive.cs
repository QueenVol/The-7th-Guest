using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestFive : MonoBehaviour
{
    [SerializeField] private Neighbor neighbor;
    [SerializeField] private GamaManager gm;

    [SerializeField] private Snap snap;
    [SerializeField] private Drag self;

    [SerializeField] private Drag preferedPersonOne;
    [SerializeField] private Drag preferedPersonTwo;
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
        if (neighbor.leftNeighbor == preferedPersonOne || neighbor.rightNeighbor == preferedPersonOne || neighbor.leftNeighbor == preferedPersonTwo || neighbor.rightNeighbor == preferedPersonTwo)
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
        Debug.Log("guestfive " + neighbor.satisfication);
    }
}
