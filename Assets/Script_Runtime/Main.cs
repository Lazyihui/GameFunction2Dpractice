using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Function2 function2;
    int a;

    [SerializeField] int limitedCount;

    [SerializeField] Vector2Int start;
    [SerializeField] Vector2Int end;

    [SerializeField] List<RectCell2> hinder = new List<RectCell2>();

    RectCell2 result;

    void Awake() {
        function2 = new Function2();
        function2.openSet.Clear();
        // a = function2.ProcessCell(start, end, hinder);

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
        } else if (Input.GetMouseButton(2)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int pos = new Vector2Int((int)mousePos.x, (int)mousePos.y);
            hinder.Add(new RectCell2 { position = pos, hCost = 10000, gCost = 10000, fCost = 1000000 });
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            function2.Start(start, end, hinder, limitedCount, out int resType, out result);
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

        if (result != null) {
            Vector2Int[] posResults = new Vector2Int[10000];
            int length = 0;
            RectCell2 cur = result;
            while (cur != null) {
                Gizmos.color = Color.yellow;
                Gizmos.DrawCube(new Vector3(cur.position.x, cur.position.y, 0), new Vector3(1, 1, 1));
                posResults[length++] = cur.position;
                cur = cur.parent;
            }
            
        }

    }


}
