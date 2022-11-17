using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform tankTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q;

        Vector3 toTarget = tankTarget.position - transform.position;
        toTarget.Normalize();

        float dot = Vector3.Dot(toTarget, Vector3.forward);
        float theta = Mathf.Acos(dot);

        q = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);

        transform.rotation = q;
    }
}
