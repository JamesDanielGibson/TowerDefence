using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
        
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
        foreach (WayPoint tile in path)
        {
            transform.position = tile.transform.position;
            yield return new WaitForSeconds(1f);
        }
        
    }
}
