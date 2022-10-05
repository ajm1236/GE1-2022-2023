using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    public float radius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        int count = 9;
        for (int j = 0; j < loops; j++)
        {
            for (int i = 0; i < loops; i++)
            {
                float angle = i * Mathf.PI * 2 / count;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                Vector3 posit = transform.position + new Vector3(x, 0, z);
                float angleDegrees = -angle * Mathf.Rad2Deg;
                Quaternion rotate = Quaternion.Euler(0, angleDegrees, 0);
                GameObject.Instantiate(prefab, posit, rotate);
            }
            radius++;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
