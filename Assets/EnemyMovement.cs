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
        print("startingPartol");
        foreach (WayPoint tile in path)
        {
            transform.position = tile.transform.position;
            print("visiting tile : " + tile.transform.position.x + "," + tile.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
        print("ending");
    }

}
