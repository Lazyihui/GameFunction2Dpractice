using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class Function
{


    public  int Astar(Vector2Int start, Vector2Int end, int limitedCount, Predicate<Vector2Int> isWalkable, Vector2Int[] result
    , bool isManuallyProcess = false)
    {
        if (!isWalkable(start) || !isWalkable(end))
        {
            return -1;
        }


        return 0;
    }
}