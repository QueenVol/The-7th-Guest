using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    //https://www.youtube.com/watch?v=axW46wCJxZ0

    public delegate void DragEndedDelegate(Drag draggableObj);

    public DragEndedDelegate dragEndedCallback;

    private bool isDrag = false;
    private Vector3 mouseDragStartPos;
    public Vector3 spriteDragStartPos;

    private Vector3 pos;

    public bool canDrag = false;

    private void Update()
    {
        pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }

    private void OnMouseDown()
    {
        if (!canDrag) return;
        isDrag = true;
        mouseDragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPos = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDrag)
        {
            transform.localPosition = spriteDragStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPos); 
        }
    }

    private void OnMouseUp()
    {
        isDrag = false;
        dragEndedCallback(this);
    }
}
