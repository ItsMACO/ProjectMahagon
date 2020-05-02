using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLogic : MonoBehaviour
{
    [SerializeField] GameObject gridPrefab;
    [SerializeField] int row = 20;
    [SerializeField] int col = 20;

    // Start is called before the first frame update
    void Start()
    {
        BuildGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BuildGrid()
    {
        for (int r = -row; r <= row; r++)
        {
            for (int c = -col; c <= col; c++)
            {
                var block = Instantiate(gridPrefab, new Vector2(r, c), Quaternion.identity) as GameObject;
                block.transform.parent = GameObject.Find("ChunkTiles").transform;
                block.gameObject.name = "Block["+r+"]["+c+"]";
                block.gameObject.tag = "GridBlock";
            }
        }
    }
}
