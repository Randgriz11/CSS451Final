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
    public GameObject Xformcontrol;
    public GameObject clubHead;
    public GameObject ballformControl;
    private Vector3 direction;
    private int counter=1;
    private bool collided = false;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
      direction = new Vector3(0,.5f,.5f);

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
        directionRotation();

        power = ballformControl.GetComponent<BallFormControl>().power;
        club = ballformControl.GetComponent<BallFormControl>().clubVector;
        inRange();
    }

    void directionRotation()
    {
        
        direction = Xformcontrol.GetComponent<XformControl>().normal;
        // Debug.Log(clubHead.transform.localPosition.normalized);
    }

    void inRange()
    {
        if (Math.Abs(this.transform.localPosition.x - club.x)<.35 && Math.Abs(this.transform.localPosition.y - club.y)<.35 && Math.Abs(this.transform.localPosition.z - club.z)<.35
            && ballformControl.GetComponent<BallFormControl>().launchPermision)
        {
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

