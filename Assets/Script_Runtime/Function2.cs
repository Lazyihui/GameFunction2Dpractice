using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function2 {

    public HashSet<RectCell2> openSetKey = new HashSet<RectCell2>();

    public HashSet<Vector2Int> openSetValuePos = new HashSet<Vector2Int>();

    public HashSet<RectCell2> closeSetKey = new HashSet<RectCell2>();

    public HashSet<Vector2Int> closeSetValuePos = new HashSet<Vector2Int>();

    // ↑ ↓ ← →
    public Vector2Int[] neighbors = new Vector2Int[] {
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(0, -1)
    };

    public void Start(Vector2Int start, Vector2Int end,/*不能走的位置先手输*/List<RectCell2> hinders) {
        closeSetKey.Clear();
        closeSetValuePos.Clear();
        for (int i = 0; i < hinders.Count; i++) {
            RectCell2 hinder = hinders[i];
            RectCell2 tem = new RectCell2();
            closeSetKey.Add(hinder);
            closeSetValuePos.Add(hinder.position);
        }

        // 添加一开始的位置
        RectCell2 startCell = new RectCell2();
        startCell.Init(start, 0, 0, 0);

        AddNeighbor(startCell, end);

    }

    public int ProcessCell(Vector2Int start, Vector2Int end,/*不能走的位置先手输*/List<RectCell2> hinders, ref int count) {


        RectCell2 nextCell = new RectCell2(); // OpenList Get FCost最小的
        nextCell = GetMinFCell(end);

        Debug.Log("最小的值是" + nextCell.position + " " + nextCell.fCost);

        openSetKey.Add(nextCell);
        openSetValuePos.Add(nextCell.position);
        if (nextCell.position == end) {
            // 结束这个函数
            Debug.Log("结束!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
            foreach (var pos in openSetValuePos) {
                Debug.Log("openSetValuePos" + pos);
            }
            return -1;

        } else {
            Debug.Log("继续");
            count++;
            if (count > 100) {
                return -1;
            } else {
                Debug.Log(count + "次");
                return ProcessCell(nextCell.position, end, hinders, ref count);

            }
        }

    }


    public void AddNeighbor(RectCell2 start_Cur, Vector2Int end) {

        for (int i = 0; i < 4; i++) {

            Vector2Int neighborPos = start_Cur.position + neighbors[i];

            if (neighborPos == end) {
                Debug.Log("走到了");
            }

            if (closeSetValuePos.Contains(neighborPos)) {

                Debug.Log(neighborPos + "已经存在不能走的位置了");

            } else {

                RectCell2 tem = new RectCell2();
                tem.position = neighborPos;
                tem.hCost = 10;
                tem.gCost = H_Manhattan(neighborPos, end);
                tem.fCost = tem.hCost + tem.gCost;
                closeSetKey.Add(tem);
            }
        }
    }

    // 找到值最小的
    public RectCell2 GetMinFCell(Vector2Int end) {

        RectCell2 minCell = null;
        // 查找所有的值 找到最小的
        foreach (var cell in closeSetKey) {

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