using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    private Snap snap;
    private Drag left;
    private Drag right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left = snap.snapOccupancy[snap.snapPoints[1]];

        if(left == snap.draggableObj[1])
        {
            Debug.Log("1");
        }
        else
        {
            Debug.Log("0");
        }
    }
}
