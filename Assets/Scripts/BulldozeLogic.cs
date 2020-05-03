using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldozeLogic : MonoBehaviour
{
    CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        Bulldoze();
    }
    private void Bulldoze()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Vector2 tilePosition = cameraController.GetTilePosition();
            BulldozeLoop(cameraController.GetMousePosInWorld());
            BulldozeLoop(tilePosition);
        }
    }
    void BulldozeLoop(Vector2 position)
    {
        RaycastHit2D hit = cameraController.MouseCast();
        if (hit && hit.transform.tag != "GridBlock")
        {
            Destroy(hit.transform.gameObject);
        }
        if (hit && hit.transform.tag == "GridBlock")
        {
            hit.transform.GetComponent<GridTile>().EnableBuilding();
        }
    }
}
