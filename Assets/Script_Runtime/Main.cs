using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Function2 function2;
    int a;

    int count;

    [SerializeField] Vector2Int start;
    [SerializeField] Vector2Int end;

    [SerializeField] List<RectCell2> hinder = new List<RectCell2>();



    void Awake() {
        count = 0;
        function2 = new Function2();
        function2.openSet.Clear();
        // a = function2.ProcessCell(start, end, hinder);

        function2.Start(start, end, hinder, count);

    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int pos = new Vector2Int((int)mousePos.x, (int)mousePos.y);
            start = pos;
        } else if (Input.GetMouseButtonDown(1)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int pos = new Vector2Int((int)mousePos.x, (int)mousePos.y);
            end = pos;
        } else if (Input.GetMouseButtonDown(2)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int pos = new Vector2Int((int)mousePos.x, (int)mousePos.y);
            hinder.Add(new RectCell2 { position = pos, hCost = 10000, gCost = 10000, fCost = 1000000 });
        }

        if (Input.GetKeyUp(KeyCode.O)) {
            a = 0;
        }

        if (a == 0) {
            if (Input.GetKeyUp(KeyCode.Space)) {
                a = function2.ProcessCell(start, end, hinder, ref count);
            }
        } else {

        }

    }

    void OnDrawGizmos() {
        for (int i = 0; i < hinder.Count; i++) {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(hinder[i].position.x, hinder[i].position.y, 0), new Vector3(1, 1, 1));
        }

        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector3(start.x, start.y, 0), new Vector3(1, 1, 1));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector3(end.x, end.y, 0), new Vector3(1, 1, 1));

        // if (function2 != null) {
        //     foreach (var pos in function2.openSetValuePos) {
        //         Gizmos.color = Color.yellow;
        //         Gizmos.DrawCube(new Vector3(pos.x, pos.y, 0), new Vector3(1, 1, 1));
        //     }
        // }

    }


}
