using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private List<Vector3> _points;
    private void Start()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;
        _lineRenderer.startColor = Color.white;
        _lineRenderer.endColor = Color.green;
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
        
        
        _points = new List<Vector3>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_lineRenderer != null)
            {
                _lineRenderer.positionCount = 0;
            }

            if (_points != null)
            {
                _points.Clear();
            }
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var raycastHit))
        {
            if (Input.GetMouseButton(0))
            {
                var point = raycastHit.point;
                point.y += 1f;
                _points.Add(point);
                _lineRenderer.positionCount = _points.Count;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1,point);
            }
        }
        
            
        
    }
}
