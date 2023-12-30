using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCode : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform originPosition;
    public Transform destinationPosition;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, originPosition.position);
        lineRenderer.SetPosition(1, destinationPosition.position);
    }
}