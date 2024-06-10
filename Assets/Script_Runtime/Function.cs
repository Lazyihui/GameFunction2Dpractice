using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class Function {
    const float G_COST = 10;

    SortedSet<RectCell> openSet = new SortedSet<RectCell>();
    Dictionary<Vector2Int, RectCell> openSetKey = new Dictionary<Vector2Int, RectCell>();
    SortedSet<RectCell> closeSet = new SortedSet<RectCell>();

    Dictionary<Vector2Int, RectCell> closeSetKey = new Dictionary<Vector2Int, RectCell>();

    Dictionary<Vector2Int, Vector2Int> childToParentDict = new Dictionary<Vector2Int, Vector2Int>();

    public int Astar(Vector2Int start, Vector2Int end, int limitedCount, Predicate<Vector2Int> isWalkable, Vector2Int[] result
    , bool isManuallyProcess = false) {
        if (!isWalkable(start) || !isWalkable(end)) {
            return -1;
        }

        openSet.Clear();
        openSetKey.Clear();
        closeSet.Clear();
        closeSetKey.Clear();

        RectCell startCell = new RectCell();
        startCell.Init(start, 0, 0, 0);
        openSet.Add(startCell);
        openSetKey.Add(startCell.position, startCell);


        int visited = 0;
        int resultCount = 0;

        if (isManuallyProcess) {
            bool isDone = ProcessCell(ref visited, ref resultCount, limitedCount, start, end, isWalkable, result, out _);
            if (isDone) {
                return resultCount;
            }
            return 0;
        }

        while (openSet.Count > 0) {
        }

        return 0;
    }

    public bool ProcessCell(ref int visited, ref int count, int limitedCount, Vector2Int satrt, Vector2Int end,
      Predicate<Vector2Int> isWalkable, Vector2Int[] result, out Vector2Int cur) {

        Vector2Int[] neighbors = new Vector2Int[] {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };

        RectCell tem = openSet.Min;

        cur = tem.position;
        openSet.Remove(tem);
        openSetKey.Remove(tem.position);
        closeSet.Add(tem);
        closeSetKey.Add(tem.position, tem);

        visited++;
        if (visited >= limitedCount) {
            count = -2;
            return true;
        }

        for (int i = 0; i < 4; i++) {

            Vector2Int neighborPos = tem.position + neighbors[i];

            if (!isWalkable(neighborPos) || closeSetKey.ContainsKey(neighborPos)) {
                continue;
            }

            if (neighborPos == end) {
                Vector2Int curPos = tem.position;
                count = 0;
                result[count++] = end;
                result[count++] = curPos;
                while (childToParentDict.TryGetValue(curPos, out var parentPos)) {
                    result[count++] = parentPos;
                    curPos = parentPos;
                }
                return true;
            }


            float gCost = G_COST;

            float hCost = H_Manhattan(tem.position, end);

            float fCost = gCost + hCost;

            RectCell neighborCell;

            if (openSetKey.TryGetValue(neighborPos, out neighborCell)) {

            } else {
                neighborCell = new RectCell();

                neighborCell.Init(neighborPos, fCost, gCost, hCost);
                openSet.Add(neighborCell);
                openSetKey.Add(neighborPos, neighborCell);
                childToParentDict.Add(neighborPos, tem.position);

            }


        }


        return false;

    }

    static float H_Manhattan(Vector2Int cur, Vector2Int end) {
        return 10 * (Mathf.Abs(cur.x - end.x) + Mathf.Abs(cur.y - end.y));
    }
}