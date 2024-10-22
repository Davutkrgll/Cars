using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManager : EditorWindow
{
    [MenuItem("Waypoint/Waypoints Editor Tools")]
    public static void ShowWindow(){
        GetWindow<WaypointManager>("Waypoints Editor Tools");
    }
   
}
