using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    //https://www.youtube.com/watch?v=axW46wCJxZ0

    public List<Transform> snapPoints;
    public List<Drag> draggableObj;
    public float snapRange = 1f;

    public Dictionary<Transform, Drag> snapOccupancy = new Dictionary<Transform, Drag>();
    public Dictionary<Drag, Transform> currentSnapPoint = new Dictionary<Drag, Transform>();

    private void Start()
    {
        foreach (Transform snap in snapPoints)
        {
            snapOccupancy[snap] = null; 
        }

        foreach (Drag drag in draggableObj)
        {
            currentSnapPoint[drag] = null;
            drag.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(Drag drag)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(drag.transform.localPosition, snapPoint.localPosition);
            if(closestSnapPoint == null ||  currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null && closestDistance <= snapRange)
        {
            if (snapOccupancy[closestSnapPoint] != null)
            {
                Drag other = snapOccupancy[closestSnapPoint];
                other.transform.position = drag.spriteDragStartPos;
                snapOccupancy[closestSnapPoint] = drag;
                currentSnapPoint[drag] = closestSnapPoint;
                currentSnapPoint[other] = null;
            }
            else
            {
                snapOccupancy[closestSnapPoint] = drag;
                currentSnapPoint[drag] = closestSnapPoint;
            }

            drag.transform.localPosition = closestSnapPoint.localPosition;
        }
        else
        {
            foreach (var key in snapOccupancy.Keys)
            {
                if (snapOccupancy[key] == drag)
                    snapOccupancy[key] = null;
            }
            currentSnapPoint[drag] = null;
        }
    }
}
