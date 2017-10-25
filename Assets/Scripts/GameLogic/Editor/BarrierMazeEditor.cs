using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BarrierMaze))]
[CanEditMultipleObjects]
public class BarrierMazeEditor : Editor {

    BarrierMaze myTarget;

    public override void OnInspectorGUI()
    {
        myTarget = (BarrierMaze)target;
        DrawDefaultInspector();
    }

    void OnSceneGUI()
    {
        myTarget = (BarrierMaze)target;
        for (int i = 0; i < myTarget.gridNumber+1; i++) {
            // Vertical Lines
            Vector3 begin = new Vector3(i * myTarget.gridSize, 0,0);
            Vector3 end = new Vector3(i * myTarget.gridSize, 0, myTarget.gridNumber * myTarget.gridSize);
            Handles.DrawLine(begin +myTarget.transform.position, end + myTarget.transform.position);

            // Horizontal Lines
            Vector3 beginH = new Vector3(0, 0, i * myTarget.gridSize);
            Vector3 endH = new Vector3(myTarget.gridNumber * myTarget.gridSize, 0, i * myTarget.gridSize);
            Handles.DrawLine(beginH + myTarget.transform.position, endH + myTarget.transform.position);
        }
    }

}
