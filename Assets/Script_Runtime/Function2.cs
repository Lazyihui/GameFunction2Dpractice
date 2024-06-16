using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function2 {

    public HashSet<RectCell2> openSet = new HashSet<RectCell2>();

    // public HashSet<Vector2Int> openSetValuePos = new HashSet<Vector2Int>();

    public HashSet<RectCell2> closeSet = new HashSet<RectCell2>();

    public HashSet<Vector2Int> closeSetKey = new HashSet<Vector2Int>();

    // ↑ ↓ ← →
    public Vector2Int[] neighbors = new Vector2Int[] {
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(0, -1)
    };

    public int Start(Vector2Int start, Vector2Int end,/*不能走的位置先手输*/List<RectCell2> hinders, int limitedCount, out int res, out RectCell2 result) {

        int resultCount = 0;
        res = 0;
        if (start == end) {
            res = 1;
            result = new RectCell2();
            return resultCount;
        }

        closeSet.Clear();
        closeSetKey.Clear();
        openSet.Clear();
        for (int i = 0; i < hinders.Count; i++) {
            RectCell2 hinder = hinders[i];
            RectCell2 tem = new RectCell2();
            closeSet.Add(hinder);
            closeSetKey.Add(hinder.position);
        }

        // 添加一开始的位置
        RectCell2 startCell = new RectCell2();
        startCell.Init(null, start, 0, 0, 0);

        openSet.Add(startCell);

        RectCell2 output = null;
        while (res == 0) {
            res = ProcessCell(start, end, hinders, ref output);
            resultCount += 1;
            if (resultCount >= limitedCount) {
                res = -2;
                break;
            }
        }
        result = output;

        if (res == -1) {
            Debug.Log("失败, 死路");
        } else if (res == -2) {
            Debug.Log("失败, 超过限制");
        }

        return resultCount;

    }

    public int ProcessCell(Vector2Int start, Vector2Int end,/*不能走的位置先手输*/List<RectCell2> hinders, ref RectCell2 result) {

        if (openSet.Count == 0) {
            return -1;
        }

        // -1 失败, 0 还在进行中, 1 成功
        RectCell2 cur = GetMinFCell(end); // OpenList Get FCost最小的
                                          // RectCell2 nextCell = GetMinFCell(end);
        openSet.Remove(cur);
        closeSet.Add(cur);
        closeSetKey.Add(cur.position);

        for (int i = 0; i < 4; i++) {

            Vector2Int neighborPos = cur.position + neighbors[i];

            if (neighborPos == end) {
                result = cur;
                Debug.Log("走到了");
                return 1;
            }

            if (closeSetKey.Contains(neighborPos)) {

            } else {
                RectCell2 tem = new RectCell2();
                tem.parent = cur;
                tem.position = neighborPos;
                tem.hCost = 10;
                tem.gCost = H_Manhattan(neighborPos, end);
                tem.fCost = tem.hCost + tem.gCost;
                openSet.Add(tem);
            }
        }
        return 0;

    }


    // 找到值最小的
    public RectCell2 GetMinFCell(Vector2Int end) {

        RectCell2 minCell = null;
        // 查找所有的值 找到最小的
        foreach (var cell in openSet) {

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