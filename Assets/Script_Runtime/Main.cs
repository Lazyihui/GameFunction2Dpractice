using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Function2 function2;
    int a;
    void Awake() {

        function2 = new Function2();
        function2.openSetKey.Clear();
        function2.openSetValuePos.Clear();
        a = function2.ProcessCell(new Vector2Int(4, 9), new Vector2Int(8, 7), function2.hinder);
    }

    void Update() {



        if (a == 0) {
            a = function2.ProcessCell(new Vector2Int(4, 9), new Vector2Int(8, 7), function2.hinder);
        } else {

        }



    }


}
