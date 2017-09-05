using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
    int x;
    int y;
    public Coordinate(int X, int Y)
    {
        this.x = X;
        this.y = Y;
    }

    public int getX()
    {
        return this.x;
    }

    public int getY()
    {
        return this.y;
    }
    public static bool operator ==(Coordinate coord1, Coordinate coord2)
    {
        if (coord1.x == coord2.x && coord1.y == coord2.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool operator !=(Coordinate coord1, Coordinate coord2)
    {
        if (coord1.x != coord2.x || coord1.y != coord2.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return x ^ y;
    }

    public override bool Equals(object obj)
    {
        Coordinate otherGroup = (Coordinate)obj;
        return this.x == otherGroup.x && this.y == otherGroup.y;
    }
};
