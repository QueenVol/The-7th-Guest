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

    private void Start()
    {
        foreach (Transform snap in snapPoints)
        {
            snapOccupancy[snap] = null; 
        }

        foreach (Drag drag in draggableObj)
        {
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
            }
            else
            {
                snapOccupancy[closestSnapPoint] = drag;
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
        }
    }
}
