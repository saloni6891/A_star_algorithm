using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid {

    private int rows;
    private int cols;
    private GameObject[,] nodeList = new GameObject[1000, 1000];

    public Grid(int r, int c)
    {
        this.rows = r;
        this.cols = c;
    }

    public int Rows
    {
        get
        {
            return this.rows;
        }
    }

    public int Cols
    {
        get
        {
            return this.cols;
        }
    }

    
    public GameObject[,] getNodeList()
    {
        return nodeList;
    }
    
    public void CreateGrid(int startX, int startY, int nodeSize, GameObject node_prefab, Dictionary<Coordinate, NodeType> grid_map)
    {
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                GameObject nodeObject = (GameObject)GameObject.Instantiate(node_prefab, new Vector3(startX + (i * nodeSize), startY + (j * nodeSize), 1.0f), Quaternion.identity);
                Node node = nodeObject.GetComponent<Node>();
                node.setX(startX + (i * nodeSize));
                node.setY(startY + (j * nodeSize));

                Coordinate coord = new Coordinate(i, j);
                if (grid_map.ContainsKey(coord))
                {
                    node.setType(grid_map[coord]);
                }
                else
                {
                    node.setType(NodeType.Path);
                }
                nodeList[i, j] = nodeObject;
            }
        }
    }
}
