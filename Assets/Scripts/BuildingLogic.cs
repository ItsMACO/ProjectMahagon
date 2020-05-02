using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingLogic : MonoBehaviour
{
    CameraController cameraController;
    [SerializeField] GameObject houseBasic;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        BuildBuilding();
    }
    void BuildBuilding()
    {
        if (Input.GetButton("Fire1"))
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Vector2 tilePosition = cameraController.GetTilePosition();
            if (GameObject.Find("House[" + tilePosition.x + "][" + tilePosition.y + "]") || GameObject.Find("Road[" + tilePosition.x + "][" + tilePosition.y + "]"))
            {

            }
            else
            {
                var house = Instantiate(houseBasic, tilePosition, Quaternion.identity) as GameObject;
                house.transform.parent = GameObject.Find("HouseTiles").transform;
                house.gameObject.name = "House[" + tilePosition.x + "][" + tilePosition.y + "]";
                house.gameObject.tag = "House";
            }
        }
        
    }
}
