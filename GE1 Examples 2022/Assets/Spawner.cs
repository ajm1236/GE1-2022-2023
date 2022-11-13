using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int count = 0;
    public GameObject tank;
    System.Collections.IEnumerator Spawn()
    {
        if(count < 5)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(-10, -10), 7, Random.Range(-10, 10));
            g.AddComponent<Rigidbody>();
            g.transform.position = transform.position;
            yield return new WaitForSeconds(.2f);
            count++;
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       StartCoroutine(Spawn());

    }
}
