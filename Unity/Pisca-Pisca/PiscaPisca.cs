using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;

public class piscaPiscaCode : MonoBehaviour
{
    public GameObject lampada;
    public float frequency;

    public GameObject lampada2;
    public float frequency2;

    public GameObject lampada3;
    public float frequency3;

    public GameObject lampada4;
    public float frequency4;

    bool changeColor = false;
    int intervalMs = 0;
    Renderer objRenderer;
    Renderer objRenderer2;
    Renderer objRenderer3;
    Renderer objRenderer4;
    Stopwatch sw = new Stopwatch(); 

    void Start()
    {
        objRenderer = lampada.GetComponent<Renderer>();
        intervalMs = (int)(1000 / frequency);
        objRenderer2 = lampada2.GetComponent<Renderer>();
        intervalMs = (int)(1000 / frequency);
        objRenderer3 = lampada3.GetComponent<Renderer>();
        intervalMs = (int)(1000 / frequency);
        objRenderer4 = lampada4.GetComponent<Renderer>();
        intervalMs = (int)(1000 / frequency);
        sw.Start();
        Thread t = new Thread(ComputeTime);
        t.Priority = System.Threading.ThreadPriority.Highest;
        t.Start();
    }

    void ComputeTime()
    {
        while (true)
        {
            if (sw.ElapsedMilliseconds >= intervalMs)
            {
                changeColor = !changeColor;
                sw.Restart();
            }
        }
    }
    void Update()
    {
        if (changeColor)
        {
            objRenderer.material.SetColor("_Color", Color.green);
            objRenderer2.material.SetColor("_Color", Color.red);
            objRenderer3.material.SetColor("_Color", Color.cyan);
            objRenderer4.material.SetColor("_Color", Color.blue);
        } else
        {
            objRenderer.material.SetColor("_Color", Color.red);
            objRenderer2.material.SetColor("_Color", Color.green);
            objRenderer3.material.SetColor("_Color", Color.blue);
            objRenderer4.material.SetColor("_Color", Color.cyan);
        }
    }
}


