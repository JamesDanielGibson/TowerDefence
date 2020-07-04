using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        FollowPath();
    }

    IEnumerator FollowPath()
    {
        foreach (WayPoint tile in path)
        {
            transform.position = tile.transform.position;
            yield return new WaitForSeconds(1f);
        } 
    }
}
