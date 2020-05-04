using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTileLogic : MonoBehaviour
{
    GameLogic gameLogic;
    CameraController cameraController;

    RaycastHit2D hit;

    string tileName;
    Vector3 tilePosition;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLogic.IsBuildModeEnabled() == false)
        {
            hit = cameraController.MouseCast();
            if(hit)
            {
                tileName = hit.transform.name;
                tilePosition = hit.transform.position;

                Debug.Log(tileName + ", " + tilePosition);
            }

        }
    }
}
