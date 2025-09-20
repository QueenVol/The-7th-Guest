using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    [SerializeField] private Snap snap;
    [SerializeField] private Drag self;
    private Drag leftNeighbor;
    private Drag rightNeighbor;
    private Transform currentSnapPoint;
    private int snapPointLoc;
    private int leftSnapPoint;
    private int rightSnapPoint;

    private void Update()
    {
        SelfPos();
        FindLeftNeighbor();
        FindRightNeighbor();
    }

    private void SelfPos()
    {
        currentSnapPoint = snap.currentSnapPoint[self];
        Debug.Log(currentSnapPoint);
        snapPointLoc = snap.snapPoints.IndexOf(currentSnapPoint);
    }

    private void FindLeftNeighbor()
    {
        leftSnapPoint = snapPointLoc + 1;
        if (leftSnapPoint >= snap.snapPoints.Count)
        {
            leftSnapPoint = 0;
        }
        Debug.Log(leftSnapPoint);
        leftNeighbor = snap.snapOccupancy[snap.snapPoints[leftSnapPoint]];
    }

    private void FindRightNeighbor()
    {
        rightSnapPoint = snapPointLoc - 1;
        if (rightSnapPoint < 0)
        {
            rightSnapPoint = snap.snapPoints.Count - 1;
        }
        Debug.Log(rightSnapPoint);
        rightNeighbor = snap.snapOccupancy[snap.snapPoints[rightSnapPoint]];
    }
}
