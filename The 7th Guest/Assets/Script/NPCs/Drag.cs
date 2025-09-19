using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public delegate void DragEndedDelegate(Drag draggableObj);

    public DragEndedDelegate dragEndedCallback;

    private bool isDrag = false;
    private Vector3 mouseDragStartPos;
    private Vector3 spriteDragStartPos;

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
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
