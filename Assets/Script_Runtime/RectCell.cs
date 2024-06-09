using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RectCell
{
    public Vector2Int position;

    public int fCost;
    public int gCost;
    public int hCost;

    public void Init(Vector2Int position, int fCost, int gCost, int hCost)
    {
        this.position = position;
        this.fCost = fCost;
        this.gCost = gCost;
        this.hCost = hCost;
    }

}