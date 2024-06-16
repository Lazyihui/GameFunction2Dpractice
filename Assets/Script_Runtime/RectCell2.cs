using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RectCell2 {
    public Vector2Int position;

    public float fCost;
    public float gCost;
    public float hCost;

    public RectCell2 parent;

    public void Init(RectCell2 parent, Vector2Int position, float fCost, float gCost, float hCost) {
        this.parent = parent;
        this.position = position;
        this.fCost = fCost;
        this.gCost = gCost;
        this.hCost = hCost;
    }

}