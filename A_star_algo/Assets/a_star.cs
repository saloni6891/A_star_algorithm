using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static void a_star(Node startingNode, List<Node> nodelist)
{
    List<Node> openList = new List<Node>();
    List<Node> closedList = new List<Node>();

    openList.Add(startingNode);
    startingNode.setF(0);

    while (openList.Count != 0)
    {
        int min = find_minimum(openList);
        Node q = openList[min];
        openList.Remove(q);
        Node[] successor = new Node[8];
        //initialise all these successors



    }

}

public static int find_minimum(List<Node> list)
{
    int minIndex = 0;
    for(int i = 1; i < list.Count; i++)
    {
        if (list[i].getF() < list[minIndex].getF())
        {
            minIndex = i;
        }
    }
    return minIndex;
}
