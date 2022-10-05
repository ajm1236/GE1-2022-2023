using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float f = Input.GetAxis("Vertical");
        float g = Input.GetAxis("Horizontal");
        Debug.Log("f: " + f);
        Debug.Log("g: " + g);
        transform.Translate(g * speed * Time.deltaTime, 0, f * speed * Time.deltaTime);

    }
}
