using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TheBarrier : MonoBehaviour
{
    public static TheBarrier theBarrier;
    public float D;
    public Vector3 Vn;
    // Start is called before the first frame update
    void Start()
    {
        // Setup for static instance
        if(theBarrier == null)
        {
            theBarrier = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

     public static bool Touching(Vector3 pos)
    {
        return (Mathf.Abs((theBarrier.transform.position - pos).magnitude) < theBarrier.transform.localScale.x / 2f);
    }
    
    public static bool Infront(Vector3 pos)
    {
        return Vector3.Dot(pos, theBarrier.Vn) > theBarrier.D;
    }
    

    // Update is called once per frame
    void Update()
    {
        Vn = -transform.forward;
        D = Vector3.Dot(Vn, transform.position);
    }

}
