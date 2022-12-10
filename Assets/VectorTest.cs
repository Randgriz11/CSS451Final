using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class VectorTest : MonoBehaviour
{
    
    
   
    
    public GameObject sphere;
    // Update is called once per frame
    private int bounceCounter;
    public Vector3 lastPosition = Vector3.zero;
    public float smoothness = .5f;
    public static float upSpeed = .2f;
    private bool bounced = true;
    private void Start()
    {

    }

    void Update()
    {
        if (sphere.transform.position.y > lastPosition.y)
        {
            lastPosition = sphere.transform.localPosition;
            
        }




        if (bounced)
        {
            sphere.transform.position = sphere.transform.position - sphere.transform.up*.1f;
            //sphere.transform.position += new Vector3(.01f, upSpeed, 0);
            //upSpeed -= .0001f;
        }
        else
        {
            

            sphere.transform.position=Vector3.Lerp(sphere.transform.position,lastPosition/2, smoothness*Time.fixedDeltaTime);
            if (transform.position.y-1  >= (lastPosition.y ))
            {

                bounced = true;
                
            }
        }
    }
    
    private void onColl(Collider collision)
    {
        // Check if the sphere has collided with the floor
        if (collision.gameObject.name == "Floor")
        {
            bounced = false;
            // // Reverse the upTest vector to make the sphere bounce
            Debug.Log("In The bounce");
            // sphere.transform.position += new Vector3(.01f, upSpeed, 0);
            // upSpeed = -upSpeed;
            // bounceCounter++;
            // Debug.Log(bounceCounter);
            // upSpeed  =  -1 * (bounceCounter * upSpeed);
        }
    }
}
