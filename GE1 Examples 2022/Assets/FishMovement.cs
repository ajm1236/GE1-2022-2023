using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Transform Head;
    public Transform Tail;

    [Range(0, 10)]
    public float frequency = 5;

    public float headAmp = 40;
    public float tailAmp = 60;
    public float Theta = 0;

    void Start(){}

    // Update is called once per frame
    void Update()
    {
        Theta = (frequency * Time.time) * 2;
        float headRot = headAmp * Mathf.Sin(Theta);
        float tailRot = tailAmp * Mathf.Sin(Theta);

        Head.localRotation = Quaternion.AngleAxis(headRot, Vector3.forward);
        Tail.localRotation = Quaternion.AngleAxis(tailRot, Vector3.forward); 
    }
}