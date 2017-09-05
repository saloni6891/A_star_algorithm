using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{

    private int x;
    private int y;
    private NodeType type;

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    public void setX(int X)
    {
        x = X ;
    }

    public void setY(int Y)
    {
        y = Y;
    }

    public NodeType getType()
    {
        return type;
    }

    public void setType(NodeType nodeType)
    {
        type = nodeType;
        setColorofNodeType(type);
    }

    void setColorofNodeType(NodeType type)
    {
        switch (type)
        {
            case NodeType.AIPlayer:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case NodeType.AIEnemy:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case NodeType.Walls:
                gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
                break;
            case NodeType.Path:
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }
}
