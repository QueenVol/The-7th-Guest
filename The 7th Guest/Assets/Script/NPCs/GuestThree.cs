using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestThree : MonoBehaviour
{
    [SerializeField] private Neighbor neighbor;
    [SerializeField] private GamaManager gm;

    [SerializeField] private Snap snap;
    [SerializeField] private Drag self;

    [SerializeField] private Drag preferedPerson;

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
        if (neighbor.leftNeighbor == preferedPerson || neighbor.rightNeighbor == preferedPerson)
        {
            neighbor.satisfication += 0.2f;
            neighbor.satisfication = Mathf.Clamp(neighbor.satisfication, 0f, 1f);
        }
        else
        {
            neighbor.satisfication -= 0.2f;
            neighbor.satisfication = Mathf.Clamp(neighbor.satisfication, 0f, 1f);
        }
        Debug.Log("guestthree " + neighbor.satisfication);
    }
}
