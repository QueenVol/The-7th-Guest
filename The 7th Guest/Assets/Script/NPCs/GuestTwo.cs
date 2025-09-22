using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestTwo : MonoBehaviour
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
        if (snap.currentSnapPoint[self] == snap.snapPoints[1] || snap.currentSnapPoint[self] == snap.snapPoints[3] || snap.currentSnapPoint[self] == snap.snapPoints[5] || snap.currentSnapPoint[self] == snap.snapPoints[7])
        {
            neighbor.satisfication += 0.2f;
            neighbor.satisfication = Mathf.Clamp(neighbor.satisfication, 0f, 1f);
        }
        else
        {
            neighbor.satisfication -= 0.2f;
            neighbor.satisfication = Mathf.Clamp(neighbor.satisfication, 0f, 1f);
        }
        Debug.Log("guesttwo " + neighbor.satisfication);
    }
}
