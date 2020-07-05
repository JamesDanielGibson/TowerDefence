using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;
    [SerializeField]public bool isExplored = false;
    [SerializeField]public WayPoint breadcrumb;

    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize),
             Mathf.RoundToInt(transform.position.z / gridSize)
             );
    }
    
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRender =  transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;
    }

    void Update()
    {
        
    }
}
