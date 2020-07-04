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

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        
        LoadBlocks();
        ColorStartAndEnd();
        //ExploreNeighbours();
        PathFind();
    }

    private void PathFind()
    {
        queue.Enqueue(startPoint);
        while(queue.Count>0&& isRunning)
        {
            var searchItem = queue.Dequeue();
            HaltStartEqualsEnd();
            ExploreNeighbours(searchItem);
            //if (!isRunning) { break; }
        }
    }

    void HaltStartEqualsEnd()
    {
        if (startPoint.GetGridPos() == endPoint.GetGridPos())
        {
            print("but im already here?");// todo remove this later
            isRunning = false;
        }
    }
    void ExploreNeighbours(WayPoint from)
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = from.GetGridPos() + direction;
            print("exploring"+ neighbourCoords);//todo remove this later
            try
            {
                WayPoint neighbour = grid[neighbourCoords];
                neighbour.SetTopColor(Color.blue);// move to somewhere else
                queue.Enqueue(neighbour);
                print("queueing neighbour");
            }
            catch
            {
                print("Skipping");// remove this later
            }
            
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