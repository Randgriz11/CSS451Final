using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Power : MonoBehaviour
{
    private float power;
    private Vector3 club;
    public GameObject ballformControl;
    public Vector3 direction = new Vector3(.1f,.1f,.45f);
    private int counter=1;
    private bool collided = false;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Launch()
    {
        velocity = power * direction;
        GetComponent<Rigidbody>().velocity = velocity;
        ballformControl.GetComponent<BallFormControl>().launchPermision = false;
    }

    // Update is called once per frame
    void Update()
    {
        power = ballformControl.GetComponent<BallFormControl>().power;
        club = ballformControl.GetComponent<BallFormControl>().clubVector;
        inRange();
    }

    void Contact()
    {
        
    }

    void inRange()
    {
        if (Math.Abs(this.transform.localPosition.x - club.x)<.5 && Math.Abs(this.transform.localPosition.y - club.y)<.5 && Math.Abs(this.transform.localPosition.z - club.z)<.5
            && ballformControl.GetComponent<BallFormControl>().launchPermision)
        {
            Debug.Log("Fs");
            Launch();
        }
       
        
    }
    
    
    
    
    
    private void onCollisionEnter(Collision collision)
    {
        // Check if the sphere has collided with the floor
        if (collision.gameObject.tag == "Walle")
            Debug.Log("LOl");
            collided = true;
        }
    }

