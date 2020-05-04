using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mousePosition;
    [SerializeField] TextMeshProUGUI numberOfHouses;
    [SerializeField] TextMeshProUGUI numberOfRoads;
    [SerializeField] TextMeshProUGUI buildModeText;
    [SerializeField] TextMeshProUGUI framesPerSecondText;

    new Camera camera;
    CameraController cameraController;
    GameLogic gameLogic;
    int fps;
    float refreshRate = 1f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        cameraController = FindObjectOfType<CameraController>();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition.text = cameraController.GetMousePosInWorld().ToString();
        numberOfHouses.text = GetNumberOfHouses().ToString();
        numberOfRoads.text = GetNumberOfRoads().ToString();
        buildModeText.text = gameLogic.IsBuildModeEnabled().ToString();
        framesPerSecondText.text = GetFramesPerSecond().ToString();
    }
    int GetNumberOfHouses()
    {
        int noHouses = GameObject.FindGameObjectsWithTag("House").Length;
        return noHouses;
    }
    int GetNumberOfRoads()
    {
        int noRoads = GameObject.FindGameObjectsWithTag("Road").Length;
        return noRoads;
    }
    int GetFramesPerSecond()
    {
        if(Time.unscaledTime > timer)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            timer = Time.unscaledTime + refreshRate;
        }
        return fps;
    }
}
