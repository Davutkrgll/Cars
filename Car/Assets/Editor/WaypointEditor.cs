using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[InitializeOnLoad()]

public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmos(WayPoints waypoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected) !=0)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.red * 0.5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position, 5f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.waypointWidth / 2f),waypoint.transform.position - (waypoint.transform.right * waypoint.waypointWidth / 2f));
    

        if (waypoint.previouslyWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset =waypoint.transform.right * waypoint.waypointWidth /2f;
            Vector3 offsetTo = waypoint.previouslyWaypoint.transform.right * waypoint.previouslyWaypoint.waypointWidth/2f;

            Gizmos.DrawLine(waypoint.transform.position + offset,waypoint.previouslyWaypoint.transform.position+offsetTo);
            
        }
        if (waypoint.nextWayPoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset =waypoint.transform.right * -waypoint.waypointWidth /2f;
            Vector3 offsetTo = waypoint.previouslyWaypoint.transform.right * -waypoint.previouslyWaypoint.waypointWidth/2f;

            Gizmos.DrawLine(waypoint.transform.position + offset,waypoint.previouslyWaypoint.transform.position+offsetTo);
            
        }
    }

}