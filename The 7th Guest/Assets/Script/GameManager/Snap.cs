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
        snapOccupancy.Clear();
        foreach (Transform snap in snapPoints)
        {
            if (!snapOccupancy.ContainsKey(snap))
            {
                snapOccupancy[snap] = null;
            }
        }

        currentSnapPoint.Clear();
        foreach (Drag drag in draggableObj)
        {
            if (!currentSnapPoint.ContainsKey(drag))
            {
                currentSnapPoint[drag] = null;
            }

            drag.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(Drag drag)
    {
        float closestDistance = float.MaxValue;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(drag.transform.position, snapPoint.position);
            if(closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null && closestDistance <= snapRange)
        {
            Drag occupant = null;
            snapOccupancy.TryGetValue(closestSnapPoint, out occupant);

            if (occupant != null)
            {
                ReturnToStart(drag);
                return;
            }

            Transform oldPoint;
            if (currentSnapPoint.TryGetValue(drag, out oldPoint) && oldPoint != null)
            {
                if (snapOccupancy.ContainsKey(oldPoint) && snapOccupancy[oldPoint] == drag)
                    snapOccupancy[oldPoint] = null;
            }

            snapOccupancy[closestSnapPoint] = drag;
            currentSnapPoint[drag] = closestSnapPoint;

            drag.transform.position = closestSnapPoint.position;
        }
        else
        {
            Transform oldPoint;
            if (currentSnapPoint.TryGetValue(drag, out oldPoint) && oldPoint != null)
            {
                if (snapOccupancy.ContainsKey(oldPoint) && snapOccupancy[oldPoint] == drag)
                    snapOccupancy[oldPoint] = null;
                currentSnapPoint[drag] = null;
            }

            ReturnToStart(drag);
        }
    }

    private void ReturnToStart(Drag drag)
    {
        drag.transform.position = drag.spriteDragStartPos;
    }
}