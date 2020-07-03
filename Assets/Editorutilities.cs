using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]// this makes the script execute while the editor is running, this can be used to make the creating of the game easier for the dev.
[SelectionBase]// this makes sure that when you select the object, in this case, it will be the whole cibe and not one of the quads.
public class Editorutilities : MonoBehaviour
{
    [SerializeField][Range(1f,20f)] float gridSize = 10f;

    TextMesh textMesh;

    void Update()
    {
        Vector3 snapPosition;
        
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

        textMesh = GetComponentInChildren<TextMesh>();// this looks for any child that might be the same type that you have specified.
        string labelText =  snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;

    }

}
