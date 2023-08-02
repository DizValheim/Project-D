using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.green;
    [SerializeField] Color pathColor = Color.blue;

    GridManager gridManager;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() 
    {
        label = GetComponent<TextMeshPro>(); 
        label.enabled = false;

        gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();   
    }

    void ToggleLabler()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    
    void Update()
    {
        ToggleLabler();
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
            
        }
        UpdateColor();
    }

    void DisplayCoordinates()
    {
        if(gridManager == null) { return; }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void UpdateColor()
    {
        if(gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if(node == null) { return; }

        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }    
        
    }

}
