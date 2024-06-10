using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    // Start is called before the first frame update

    HashSet<Vector2Int> blockSet = new HashSet<Vector2Int>();
    Vector2Int startPos;
    Vector2Int endPos;
    Vector2Int curPos;

    Vector2Int[] result = new Vector2Int[10000];
    int resultCount = 0;

    int visited = 0;

    Function function;

    void Awake() {
        Debug.Log("Main Awake");

        function = new Function();


    }

    // Update is called once per frame
    void Update() {


        Vector2Int mouseGridPos = MouseGridPos();
        if (Input.GetMouseButton(0)) {
            blockSet.Add(mouseGridPos);
        } else if (Input.GetMouseButtonUp(1)) {
            startPos = mouseGridPos;
        } else if (Input.GetMouseButtonUp(2)) {
            endPos = mouseGridPos;
            visited = 0;
            resultCount = function.Astar(startPos, endPos, 5000, (pos) => {
                return !blockSet.Contains(pos);
            }, result);
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            bool hasResult = function.ProcessCell(ref visited, ref resultCount, 5000, startPos, endPos, (pos) => {
                return !blockSet.Contains(pos);
            }, result, out curPos);
            if (hasResult) {
                Debug.Log("Res: " + resultCount);
            }
        }

    }
    Vector2Int MouseGridPos() {
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2Int mouseGridPos = new Vector2Int(Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y));
        return mouseGridPos;
    }


}
