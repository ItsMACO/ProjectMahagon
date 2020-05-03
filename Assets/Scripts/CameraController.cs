using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    //Vector2 direction;
    string lastTileHover;
    DebugInfo debugInfo;
    bool debugPanelActive = true;
    bool gridEnabled = true;

    new Camera camera;
    Vector3 cameraOffset;
    Vector2 mousePos;
    Vector2 mousePosInWorld;

    void Start()
    {
        camera = Camera.main;
        transform.position = new Vector2(0, 0);
        camera.transform.position = transform.position;
        cameraOffset = new Vector3(0, 0, -1);
        debugInfo = FindObjectOfType<DebugInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GetTileName();
        SetDebugInfoState();
        ToggleGrid();

        //FaceMouse();
    }

    void Move()
    {
        if(Input.GetButtonDown("Walk"))
        {
            moveSpeed /= 2;
        }
        if(Input.GetButtonUp("Walk"))
        {
            moveSpeed *= 2;
        }
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = camera.transform.position.x + deltaX;

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = camera.transform.position.y + deltaY;

        transform.position = new Vector3(newXPos, newYPos);

        camera.transform.position = transform.position + cameraOffset;

    }
    public Vector2 GetMousePosInWorld()
    {
        mousePos = Input.mousePosition;
        mousePosInWorld = camera.ScreenToWorldPoint(mousePos);
        return mousePosInWorld;
    }
    public string GetTileName()
    {
        RaycastHit2D hit = MouseCast();
        if (hit)
        {
            return hit.transform.name;
        }
        else
        {
            return null;
        }
    }
    public Vector2 GetTilePosition()
    {
        RaycastHit2D hit = MouseCast();
        if (hit)
        {
            return hit.transform.position;
        }
        else
        {
            return new Vector2(0f, 0f);
        }
    }
    public RaycastHit2D MouseCast()
    {
        Vector2 mouseRay = new Vector2(GetMousePosInWorld().x, GetMousePosInWorld().y);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay, Vector2.zero, 5f);
        return hit;
    }
    public void SetDebugInfoState()
    {
        if(Input.GetKeyDown("tab"))
        {
            debugPanelActive = !debugPanelActive;
            if (debugPanelActive)
            {
                debugInfo.gameObject.SetActive(true);
            }
            else
            {
                debugInfo.gameObject.SetActive(false);
            }

        }
    }

    public void ToggleGrid()
    {
        if (Input.GetKeyDown("g"))
        {
            gridEnabled = !gridEnabled;
            if (gridEnabled == false)
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("GridBlock");
                foreach (GameObject g in blocks)
                {
                    g.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 0);
                }
            }
            else
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("GridBlock");
                foreach (GameObject g in blocks)
                {
                    g.gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
                }
            }
        }
    }
    public bool GetGridState()
    {
        return gridEnabled;
    }

    /*
    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

    }
    
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    */
}
