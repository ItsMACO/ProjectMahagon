using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadLogic : MonoBehaviour
{
    CameraController cameraController;
    [SerializeField] GameObject[] roadPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        BuildRoad();
    }

    void BuildRoad()
    {
        if(Input.GetButton("Fire2"))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Vector2 tilePosition = cameraController.GetTilePosition();
            if (GameObject.Find("House[" + tilePosition.x + "][" + tilePosition.y + "]") || GameObject.Find("Road[" + tilePosition.x + "][" + tilePosition.y + "]"))
            {
                
            } else
            {
                var road = Instantiate(roadPrefab[0], tilePosition, Quaternion.identity) as GameObject;
                road.transform.parent = GameObject.Find("RoadTiles").transform;
                road.gameObject.name = "Road[" + tilePosition.x + "][" + tilePosition.y + "]";
                road.gameObject.tag = "Road";
            }
        }
    }
}
