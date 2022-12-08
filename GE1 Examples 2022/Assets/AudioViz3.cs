using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz3 : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource asource;
    AudioClip aclip;
    public float[] samples;
    public float[] smoothed;
    public int frameSize = 512;

    public GameObject[] blocks;
    public float scale = 10;

    public Transform bigCube;
    void Start()
    {
        asource = GetComponent<AudioSource>();
        aclip = asource.clip;
        samples = new float[frameSize];
        smoothed = new float[frameSize];
        blocks = new GameObject[frameSize];

        for(int i = 0; i < frameSize; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 pos = new Vector3((i - (frameSize / 2)), 0, 0);
            go.transform.position = transform.TransformPoint(pos);
            blocks[i] = go;
            //blocks[i].GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float))
            blocks[i].transform.parent = this.transform;
        }
        
    }

    float average;
    float lerpAverage;
    // Update is called once per frame
    void Update()
    {
        asource.GetOutputData(samples, 0);
        float sum = 0;
        for(int i = 0; i < frameSize; i++)
        {
            float s = Mathf.Abs(samples[i]) * scale;
            smoothed[i] = Mathf.Lerp(smoothed[i], s, Time.deltaTime);
            float smoothedS = smoothed[i];
            float h = smoothedS / 2;
            Vector3 pos = blocks[i].transform.position;
            pos.y = h;
            blocks[i].transform.position = pos;
            blocks[i].transform.localScale = new Vector3(1, smoothedS, 1);
            sum += Mathf.Abs(samples[i]);
        }
        average = sum / frameSize;
        lerpAverage = Mathf.Lerp(lerpAverage, average, Time.deltaTime * 4);

        bigCube.localScale = new Vector3(lerpAverage, lerpAverage, lerpAverage) * scale;
    }
}
