using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingLogic : MonoBehaviour
{
    CameraController cameraController;
    [SerializeField] GameObject housePrefab;
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
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            RaycastHit2D hit = cameraController.MouseCast();
            if (hit.transform.tag == "GridBlock" && hit.transform.gameObject.GetComponent<GridTile>().GetBuildingState())
            {
                Vector2 tilePosition = cameraController.MouseCast().transform.position;
                var house = Instantiate(housePrefab, tilePosition, Quaternion.identity) as GameObject;
                house.transform.parent = GameObject.Find("HouseTiles").transform;
                house.gameObject.name = "House[" + tilePosition.x + "][" + tilePosition.y + "]";
                house.gameObject.tag = "House";
                hit.transform.gameObject.GetComponent<GridTile>().DisableBuilding();
            }
        }
        
    }
}
