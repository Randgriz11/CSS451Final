using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class VectorTest : MonoBehaviour
{
    public Vector3 targetPos;

    public GameObject sphere;
    // Update is called once per frame
    public float speed = 3;
    public static float upSpeed = .1f;
    private Vector3 upTest = new Vector3(0, upSpeed, 0);
    private void Start()
    {
    }

    void Update()
    {
        
        sphere.transform.position += new Vector3(.01f, upSpeed, 0);
        upSpeed-=.00001f;
    }
}
