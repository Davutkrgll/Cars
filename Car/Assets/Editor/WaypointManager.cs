using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using System;

public class WaypointManager : EditorWindow
{
    [MenuItem("Waypoint/Waypoints Editor Tools")]
    public static void ShowWindow(){
        GetWindow<WaypointManager>("Waypoints Editor Tools");
    }
    public Transform waypointOrigin;

    private void OnGUI(){
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));

        if (waypointOrigin==null)
        {
            EditorGUILayout.HelpBox("Please assign a Waypoint origin transform", MessageType.Warning);

        }
        else{
            EditorGUILayout.BeginVertical("box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }
    
    void CreateButtons(){
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
    }

     void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint"+ waypointOrigin.childCount,typeof(WayPoints));
        waypointObject.transform.SetParent(waypointOrigin, false);

        WayPoints waypoint = waypointObject.GetComponent<WayPoints>();
        if (waypointOrigin.childCount >1)
        {
            waypoint.previouslyWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount-2).GetComponent<WayPoints>();
            waypoint.previouslyWaypoint.nextWayPoint = waypoint;

            waypoint.transform.position = waypoint.previouslyWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previouslyWaypoint.transform.forward;
        }
        Selection.activeGameObject = waypointObject.gameObject;

    }
}
