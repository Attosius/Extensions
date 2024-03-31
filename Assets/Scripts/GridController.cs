using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[ExecuteInEditMode]
public class GridController : MonoBehaviour
{
    public GameObject gridItemSmall;
    //public GameObject mapOuter;
    public int mapWidth = 20;
    public List<GameObject> gridItems = new List<GameObject>();

    void Start()
    {
        //SceneView.duringSceneGui += SceneView_duringSceneGui;
    }

    //private void SceneView_duringSceneGui(SceneView view)
    //{
    //    CreateGrid();
    //}
    public void UpdateGrid(Color color)
    {
        foreach (var item in gridItems)
        {
            if (item.tag == "Colored")
            {
                item.GetComponentInChildren<SpriteRenderer>().color = color;
            }else
            {
                item.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
        }
    }

    void Awake()
    {
        CreateGrid();
        //for (float i = 0f; i < mapWidth; i++)
        //{
        //    for (float j = 0; j < mapWidth; j++)
        //    {
        //        var position = new Vector3(i / 2f, j / 2f, 0);
        //        //GUI.Label(new Rect(position, new Vector2(20, 20)), position.ToString());
        //        //Debug.Log(position);
        //        //Gizmos.
        //        Instantiate(gridItemSmall, position, Quaternion.identity, transform);
        //    }

        //}

    }

    private void CreateGrid()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                var position = new Vector3(i / 2f, j / 2f, 0);
                //if (i == -1 || i == mapWidth || j == -1 || j == mapWidth)
                //{
                //    Instantiate(mapOuter, position, Quaternion.identity, transform);
                //    continue;
                //}
                var item = Instantiate(gridItemSmall, position, Quaternion.identity, transform);
                gridItems.Add(item);
                item.tag = "Inital";
            }

        }
    }
}
