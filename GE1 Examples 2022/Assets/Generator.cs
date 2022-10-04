using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    public float radius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        int count = 5;
        for (int i = 0; i < count; i++)
        {
            float angle = i * Mathf.PI * 2 / count;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 posit = transform.position + new Vector3(x, y, 0);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rotate = Quaternion.Euler(0, 0, angleDegrees);
            GameObject.Instantiate(prefab, posit, rotate);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
