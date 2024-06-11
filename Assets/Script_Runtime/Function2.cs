using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function2 {

    public Dictionary<Vector2Int, RectCell2> openSetKey = new Dictionary<Vector2Int, RectCell2>();

    public Dictionary<Vector2Int, RectCell2> closeSetKey = new Dictionary<Vector2Int, RectCell2>();
    // ↑ ↓ ← →
    public Vector2Int[] neighbors = new Vector2Int[] {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };


    // 添加一开始的位置
    public void Init(Vector2Int start, Vector2Int end) {
        RectCell2 startCell = new RectCell2();
        startCell.Init(start, 0, 0, 0);
        openSetKey.Add(start, startCell);
    }

    public void AddNeighbor(RectCell2 start_Cur, Vector2Int end) {

        for (int i = 0; i < 4; i++) {

            Vector2Int neighborPos = start_Cur.position + neighbors[i];

            RectCell2 tem = new RectCell2();
            tem.position = neighborPos;
            tem.hCost = 10;
            tem.gCost = H_Manhattan(neighborPos,end);
            tem.fCost = 0;
            if (closeSetKey.ContainsKey(neighborPos)) {

            } else {
                closeSetKey.Add(neighborPos, tem);
            }
        }
    }

    // 找到值最小的
    public RectCell2 GetMinFCell(Vector2Int end) {

        RectCell2 minCell = null;
        // 查找所有的值 找到最小的
        foreach (var cell in closeSetKey.Values) {
            Debug.Log(closeSetKey.Values);

            if (minCell == null || cell.fCost < minCell.fCost) {
                minCell = cell;
            }

        }

        return minCell;

    }

    // g值的算法
    static float H_Manhattan(Vector2Int cur, Vector2Int end) {
        return 10 * (Mathf.Abs(cur.x - end.x) + Mathf.Abs(cur.y - end.y));
    }

}