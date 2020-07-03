using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;
    // Start is called before the first frame update
    void Start()
    {
        PrintAllWayPoints();
    }

    private void PrintAllWayPoints()
    {
        foreach (Block tile in path)
        {
            print(tile.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
