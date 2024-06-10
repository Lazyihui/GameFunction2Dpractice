using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RectCell
{
    public Vector2Int position;

    public float fCost;
    public float gCost;
    public float hCost;

    public void Init(Vector2Int position, float fCost, float gCost, float hCost)
    {
        this.position = position;
        this.fCost = fCost;
        this.gCost = gCost;
        this.hCost = hCost;
    }
    
}