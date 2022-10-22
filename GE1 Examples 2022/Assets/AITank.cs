using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    public List<Vector3> waypoints;
    public int count = 5;
    public float radius = 5;
    public Transform player;
    public float speed;


    void SetUpWaypoints()
    {
        waypoints = new List<Vector3>();
        waypoints.Clear();
        float theta = (Mathf.PI * 2.0f) / (float) count;

        for(int i = 0 ; i < count ; i ++)
        {
            float angle = i * theta;
            Vector3 p = new Vector3
                (
                    Mathf.Sin(angle) * radius, 
                    0,
                    Mathf.Cos(angle) * radius
                );
            p = transform.TransformPoint(p);
            waypoints.Add(p);

        }
    }

    void OnDrawGizmos()
    {
        SetUpWaypoints();
        foreach(Vector3 v in waypoints)
        {
            Gizmos.DrawWireSphere(v, 0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpWaypoints();

    }

    int current = 0;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, waypoints[current]);
        if (dist < 1.0f)
        {
            current = (current + 1) % waypoints.Count;
        }
        transform.LookAt(waypoints[current]);
        transform.Translate(0, 0, speed * Time.deltaTime);

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

        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        if (angle > 45 && 0 < dot && dot < 10)
        {
            GameManager.Log("Inside FOV and in range!");
        }

    }

}
