using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TravelingBall : MonoBehaviour
{
    public GameObject shadow, line;
    float speed = 0f;
    float lifeSpan = 0f;
    Vector3 contactPt, v, projection, velocity;
    // Update is called once per frame
    void Update()
    {
        // Computes where the ball is closest to the plane
        contactPt = transform.position - TheBarrier.theBarrier.Vn * transform.localScale.y * 0.5f;
        // computes the v which is the normal vector of the plane
        v = (Vector3.Dot(transform.position, TheBarrier.theBarrier.Vn) - TheBarrier.theBarrier.D) * -TheBarrier.theBarrier.Vn;
        //Computes the ball projection 
        projection = transform.position + v;
        // Computes the vlocity of ball
        velocity = speed * transform.up;
        //moves the ball based on speed
        transform.position += velocity * Time.deltaTime;


        //lifespan so the ball only exists during the time
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0)
        {
            BallSpawner.RemoveBall(gameObject);
        }

        CastShadow();
        Bounce();
    }

    public void SetParameters(float speed, float lifeSpan)
    {
        this.speed = speed;
        this.lifeSpan = lifeSpan;
       
    }

    //https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html
    //https://cosmicworks.io/blog/2019/02/implementing-planar-shadows-in-unity/
    void CastShadow()
    {
        if(TheBarrier.Infront(contactPt)  && TheBarrier.Touching(projection))
        {
            shadow.SetActive(true);
            line.SetActive(true);
            
            shadow.transform.position = projection - v.normalized * 0.05f;
            shadow.transform.up = TheBarrier.theBarrier.Vn;
            float scale = (1f - (v.magnitude / 50f)) * (1f - (v.magnitude / 50f));
            shadow.transform.localScale = new Vector3(scale, 0.1f, scale);

            Line.DrawLine(line.transform, transform.position, v, 0.02f);
        }
        else
        {
            shadow.SetActive(false);
            line.SetActive(false);
        }
    }

    void Bounce()
    {   
        /*
        Checks if the ball is going to colide by checking if it is infront of the barrier and in range of the barrier
        */
        if(TheBarrier.Infront(transform.position) && !TheBarrier.Infront(contactPt) && Vector3.Dot(velocity, TheBarrier.theBarrier.Vn) < 0 && TheBarrier.Touching(projection)) 
        {
            velocity = 2f * (Vector3.Dot(-velocity, TheBarrier.theBarrier.Vn) * TheBarrier.theBarrier.Vn) + velocity;
            transform.up = velocity.normalized;
        }
    }
}
