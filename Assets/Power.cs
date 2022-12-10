using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Power : MonoBehaviour
{
    private float power =95f;
    public GameObject ballformControl;
    public Vector3 direction = new Vector3(0, 0, 1);
    private int counter=1;
    private bool collided = false;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
        velocity = power * direction;
        GetComponent<Rigidbody>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
        power = ballformControl.GetComponent<BallFormControl>().power;
    }
    
    
    private void onCollisionEnter(Collision collision)
    {
        // Check if the sphere has collided with the floor
        if (collision.gameObject.tag == "Walle")
            Debug.Log("LOl");
            collided = true;
        }
    }

