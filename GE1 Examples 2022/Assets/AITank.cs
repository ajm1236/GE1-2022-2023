using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            
            int i;
            float theta = (Mathf.PI * 2.0f) / numWaypoints;
            for (i = 0; i < numWaypoints; i++)
            {
                float ang = theta * i;
                Vector3 pos = new Vector3(Mathf.Sin(ang) * radius, 0, Mathf.Cos(ang) * radius);
                pos = transform.TransformPoint(pos);
                // You can draw gizmos using
                Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }

    // Use this for initialization
    void Awake()
    {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List
        int i;
        float theta = (Mathf.PI * 2.0f) / numWaypoints;
        for (i = 0; i < numWaypoints; i++)
        {
            float ang = theta * i;
            Vector3 pos = new Vector3(Mathf.Sin(ang) * radius, 0, Mathf.Cos(ang) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        Vector3 tankPos = transform.position;
        Vector3 nextWayPos = waypoints[current] - tankPos;

        float gap = nextWayPos.magnitude;
        if (gap < 1)
        {
            current = (current + 1) % waypoints.Count;
        }

        transform.position = Vector3.Lerp(transform.position, waypoints[current], Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextWayPos, Vector3.up), 180 * Time.deltaTime);

        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        Vector3 front_back = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, front_back);
        if (dot > 0)
        {
            GameManager.Log("Tank is in front!");
        }
        else
        {
            GameManager.Log("Tank is behind!");
        }

        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        if (angle > 45 && 0 < dot && dot < 10)
        {
            GameManager.Log("Inside FOV and in range!");
        }
        // You can print stuff to the screen using:
        GameManager.Log("Hello from the AI tank");
    }
}
