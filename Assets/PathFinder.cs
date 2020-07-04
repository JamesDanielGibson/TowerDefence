using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
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
        print(grid.Count);
    }   
}