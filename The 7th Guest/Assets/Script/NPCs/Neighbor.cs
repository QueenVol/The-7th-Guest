using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neighbor : MonoBehaviour
{
    [SerializeField] private Snap snap;
    [SerializeField] private Drag self;
    public Drag leftNeighbor;
    public Drag rightNeighbor;
    private Transform currentSnapPoint;
    private int snapPointLoc;
    private int leftSnapPoint;
    private int rightSnapPoint;

    public float satisfication;

    [SerializeField] private Slider satisBar;
    [SerializeField] private Vector3 offset = new Vector3(0, 0.6f, 0);

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        SelfPos();
        FindLeftNeighbor();
        FindRightNeighbor();
        SatiSlider();
    }

    private void SelfPos()
    {
        currentSnapPoint = snap.currentSnapPoint[self];
        //Debug.Log(currentSnapPoint);
        snapPointLoc = snap.snapPoints.IndexOf(currentSnapPoint);
    }

    private void FindLeftNeighbor()
    {
        leftSnapPoint = snapPointLoc + 1;
        if (leftSnapPoint >= snap.snapPoints.Count)
        {
            leftSnapPoint = 0;
        }
        //Debug.Log(leftSnapPoint);
        leftNeighbor = snap.snapOccupancy[snap.snapPoints[leftSnapPoint]];
    }

    private void FindRightNeighbor()
    {
        rightSnapPoint = snapPointLoc - 1;
        if (rightSnapPoint < 0)
        {
            rightSnapPoint = snap.snapPoints.Count - 1;
        }
        //Debug.Log(rightSnapPoint);
        rightNeighbor = snap.snapOccupancy[snap.snapPoints[rightSnapPoint]];
    }

    private void SatiSlider()
    {
        if (satisBar != null)
        {
            satisBar.value = satisfication;

            Vector3 screenPos = cam.WorldToScreenPoint(transform.position + offset);

            satisBar.transform.position = screenPos;
        }
    }
}
