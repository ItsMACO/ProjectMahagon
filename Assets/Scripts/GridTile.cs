using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    new SpriteRenderer renderer;
    [SerializeField] bool buildingEnabled = true;

    //COLOURS
    Color32 lightblue = new Color32(0, 203, 255, 255);
    Color32 white = new Color32(255, 255, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        PaintTile(lightblue);
    }
    void OnMouseExit()
    {
        PaintTile(white);
    }
    void PaintTile(Color32 tileColor)
    {
        renderer.material.color = tileColor;
    }
    public void DisableBuilding()
    {
        buildingEnabled = false;
    }
    public void EnableBuilding()
    {
        buildingEnabled = true;
    }
    public bool GetBuildingState()
    {
        return buildingEnabled;
    }
}
