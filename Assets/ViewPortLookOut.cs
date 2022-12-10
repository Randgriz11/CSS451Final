using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortLookOut : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform theCamera;
   
    // Update is called once per frame
    void Start()
    {
        theCamera.LookAt(target);

    }
    void LateUpdate()
    {
        theCamera.transform.position = target.transform.position + new Vector3(0,0,-5) ;
    }
}
