using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startPoint;
    [SerializeField] WayPoint endPoint;

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    bool isRunning = true;
    WayPoint searchItem;
    private List<WayPoint> path = new List<WayPoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    private void ColourStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    public List<WayPoint> GetPath()
    {
        LoadBlocks();
        ColourStartAndEnd();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        WayPoint prev = endPoint.breadcrumb;
        while(prev!= startPoint)
        {
            path.Add(prev);
            prev = prev.breadcrumb;
        }
        path.Add(startPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while(queue.Count>0 && isRunning)
        {
            searchItem = queue.Dequeue();
            searchItem.isExplored = true;
            HaltStartEqualsEnd();
            ExploreNeighbours();
        }
    }

    void HaltStartEqualsEnd()
    {
        if (searchItem == endPoint)
        {
            isRunning = false;
        }
    }

    void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = searchItem.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoords)) { QueueNewNeighbour(neighbourCoords); } 
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoords)
    {
        WayPoint neighbour = grid[neighbourCoords];
        
        if (neighbour.isExplored||queue.Contains(neighbour))
        {}
        else
        {
            queue.Enqueue(neighbour);
            neighbour.breadcrumb = searchItem;
        }
        
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.cyan);
        endPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();// this creates an array of waypoints.
        foreach ( WayPoint waypoint in waypoints)// this loops through all the waypoints in the world
        {
            if(grid.ContainsKey(waypoint.GetGridPos()))// if there is a duplicate then a debug message will be printed.
            {
                Debug.LogWarning("Overlapping blocks in world"+waypoint);
            }else// otherwise the waypoint will be added to the deictionary.
            {
                grid.Add(waypoint.GetGridPos(), waypoint); 
            }  
        }
    }   
}