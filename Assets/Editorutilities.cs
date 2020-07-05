using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]// this makes the script execute while the editor is running, this can be used to make the creating of the game easier for the dev.
[SelectionBase]// this makes sure that when you select the object, in this case, it will be the whole cibe and not one of the quads.
[RequireComponent(typeof(WayPoint))]
public class Editorutilities : MonoBehaviour
{
    
    WayPoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<WayPoint>();
        
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(
            waypoint.GetGridPos().x * waypoint.GetGridSize(), 
            0f, 
            waypoint.GetGridPos().y*waypoint.GetGridSize()//uses a 2d vector so instead of xyz we only have xy, so in this case y maps to z.
        );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();// this looks for any child that might be the same type that you have specified.
        string labelText = waypoint.GetGridPos().x  + "," + waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
