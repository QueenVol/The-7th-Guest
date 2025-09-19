using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    [SerializeField] private Snap snap;
    private Drag leftNeighbor;
    private Drag rightNeighbor;
    private Transform currentSnapPoint;
    private int snapPointLoc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        currentSnapPoint = snap.currentSnapPoint[snap.draggableObj[0]];
        snapPointLoc = snap.snapPoints.IndexOf(currentSnapPoint);
        Debug.Log(snapPointLoc);
    }

    private void FindLeftNeighbor()
    {

    }

    private void FindRightNeighbor()
    {

    }
}
