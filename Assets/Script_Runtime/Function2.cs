using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function2 {

    public HashSet<RectCell2> openSetKey = new HashSet<RectCell2>();

    public HashSet<RectCell2> closeSetKey = new HashSet<RectCell2>();
    // ↑ ↓ ← →
    public Vector2Int[] neighbors = new Vector2Int[] {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };

    public RectCell2[] hinder = new RectCell2[]{
        new RectCell2 { position = new Vector2Int(6, 9) , hCost = 10000, gCost = 10000, fCost = 1000000},
        new RectCell2 { position = new Vector2Int(7, 9) , hCost = 10000, gCost = 10000, fCost = 1000000},
        new RectCell2 { position = new Vector2Int(8, 9) , hCost = 10000, gCost = 10000, fCost = 1000000}
    };

    public int ProcessCellMain(Vector2Int start, Vector2Int end,/*不能走的位置先手输*/RectCell2[] hinders) {

        closeSetKey.Clear();
        for (int i = 0; i < 3; i++) {
            RectCell2 hinder = hinders[i];
            RectCell2 tem = new RectCell2();
            closeSetKey.Add(hinder);
        }

        // 添加一开始的位置
        RectCell2 startCell = new RectCell2();
        startCell.Init(start, 0, 0, 0);
        openSetKey.Add(startCell);

        AddNeighbor(startCell, end);

        RectCell2 nextCell = new RectCell2();

        nextCell = GetMinFCell(end);

        openSetKey.Add(nextCell);
        if (nextCell.position == end) {
            // 结束这个函数

            return -1;

        } else {
            return 0;
        }

    }



    public int ProcessCell(Vector2Int start, Vector2Int end,/*不能走的位置先手输*/RectCell2[] hinders) {

        // 添加一开始的位置
        RectCell2 startCell = new RectCell2();
        startCell.Init(start, 0, 0, 0);

        AddNeighbor(startCell, end);

        RectCell2 nextCell = new RectCell2();

        nextCell = GetMinFCell(end);

        openSetKey.Add(nextCell);
        if (nextCell.position == end) {
            // 结束这个函数

            return -1;

        } else {
            return 0;
        }

    }


    public void AddNeighbor(RectCell2 start_Cur, Vector2Int end) {

        for (int i = 0; i < 4; i++) {

            Vector2Int neighborPos = start_Cur.position + neighbors[i];

            RectCell2 tem = new RectCell2();
            tem.position = neighborPos;
            tem.hCost = 10;
            tem.gCost = H_Manhattan(neighborPos, end);
            tem.fCost = tem.hCost + tem.gCost;

            if (neighborPos == end) {
                Debug.Log("走到了");
            }

            if (closeSetKey.Contains(tem)) {
                Debug.Log("已经存在");

            } else {
                Debug.Log(tem.fCost);
                closeSetKey.Add(tem);
            }
        }
    }

    // 找到值最小的
    public RectCell2 GetMinFCell(Vector2Int end) {

        RectCell2 minCell = null;
        // 查找所有的值 找到最小的
        foreach (var cell in closeSetKey) {

            // Debug.Log(closeSetKey.Values);

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