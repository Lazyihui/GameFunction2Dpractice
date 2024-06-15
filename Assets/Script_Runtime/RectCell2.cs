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

    public Vector2Int ParentPosition {
        get {
            if (parent == null) {
                return new Vector2Int(-1, -1);
            }
            return parent.position;
        }
    }

    public void Init(Vector2Int position, float fCost, float gCost, float hCost) {
        this.position = position;
        this.fCost = fCost;
        this.gCost = gCost;
        this.hCost = hCost;
    }

}