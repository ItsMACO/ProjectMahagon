using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadLogic : MonoBehaviour
{
    CameraController cameraController;
    GameLogic gameLogic;

    GridTile gridTile;
    [SerializeField] GameObject[] roadPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        BuildRoad();
    }

    void BuildRoad()
    {
        if(Input.GetButton("Fire3") && gameLogic.IsBuildModeEnabled())
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            RaycastHit2D hit = cameraController.MouseCast();
            if(hit.transform.tag == "GridBlock" && hit.transform.gameObject.GetComponent<GridTile>().GetBuildingState())
            {
                Vector2 tilePosition = cameraController.MouseCast().transform.position;
                var road = Instantiate(roadPrefab[0], tilePosition, Quaternion.identity) as GameObject;
                road.transform.parent = GameObject.Find("RoadTiles").transform;
                road.gameObject.name = "Road[" + tilePosition.x + "][" + tilePosition.y + "]";
                road.gameObject.tag = "Road";
                hit.transform.gameObject.GetComponent<GridTile>().DisableBuilding();
            }
        }
    }
}
