using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableGrid : MonoBehaviour
{
    GridScript gridInstance;
    public bool IsSelected = false;
    public string currentGrid;
    // Use this for initialization
    void Start()
    {
        currentGrid = transform.parent.name;
        gridInstance = GameObject.Find("Grid").GetComponent<GridScript>();
    }

    // Update is called once per frame
    void Update()
    {
        HighlightIfSelected();
    }

    void HighlightIfSelected()
    {
        if (IsSelected)
        {
            var mat = GetComponentInChildren<Renderer>().material;
            mat.color = Color.green;
        }
    }

    private void OnMouseOver()
    {
        var mat = GetComponentInChildren<Renderer>().material;
        mat.color = Color.green;
    }

    private void OnMouseExit()
    {
        var mat = GetComponentInChildren<Renderer>().material;
        mat.color = Color.white;
    }

    private void OnMouseDown()
    {
        Debug.Log(currentGrid);
        bool wasSelected = IsSelected;
        IsSelected = !IsSelected;
        Debug.Log("Selected " + (IsSelected ? "True" : "False"));

        if (!gridInstance.HasOneGridSelected)
        {
            gridInstance.HasOneGridSelected = true;
            gridInstance.SelectedGrid = currentGrid;
        }
        else
        {
            IsSelected = false;
        }

        if(wasSelected)
        {
            gridInstance.HasOneGridSelected = false;
        }

    }
}
