using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using System.Text;
using System.IO;

public enum NodeType
{
    AIPlayer,
    AIEnemy,
    Walls,
    Path,
}

public class GridManager : MonoBehaviour {


    public int rows;
    public int columns;
    public int start_posX;
    public int start_posY;
    public int node_size;
    public GameObject node_prefab;
    Dictionary<Coordinate, NodeType> coordToType = new Dictionary<Coordinate, NodeType>();

	// Use this for initialization
	void Start () {
        Grid grid = new Grid(rows, columns);
        ParseAndPopulateMap();
        grid.CreateGrid(start_posX, start_posY, node_size, node_prefab, coordToType);

    }

    public void Update()
    {
        
    }

    private void ParseAndPopulateMap()
    {
        string line;
        StreamReader theReader = new StreamReader("Assets/Grid_map.txt", Encoding.Default);
        using (theReader)
        {
            do
            {
                line = theReader.ReadLine();

                if (line != null)
                {
                    string[] entries = line.Split(',');
                    if (entries.Length > 0)
                    {
                        Coordinate coord = new Coordinate(Int32.Parse(entries[0]), Int32.Parse(entries[1]));
                        coordToType.Add(coord, stringToNodeType(entries[2]));
                    }
                }
            }
            while (line != null);
        }
        theReader.Close();
    }

    private NodeType stringToNodeType(string type)
    {
        switch (type)
        {
            case "AIPlayer":
                return NodeType.AIPlayer;
            case "AIEnemy":
                return NodeType.AIEnemy;
            case "Wall":
                return NodeType.Walls;
            case "Path":
                return NodeType.Path;
            default:
                return NodeType.Path;
        }
    }
}