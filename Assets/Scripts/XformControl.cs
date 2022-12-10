using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XformControl : MonoBehaviour {
    
    public SliderWithEcho X, Y, Z;
    public Text ObjectName;
    
    public Transform mBaseNode;
    public Transform mBodyNode;
    private Vector3 mPreviousSliderValues = Vector3.zero;
    private bool axisOn= false;

	// Use this for initialization
	void Start () {
     
       
        X.SetSliderListener(XValueChanged);
        Y.SetSliderListener(YValueChanged);
        Z.SetSliderListener(ZValueChanged);
        ObjectSetUI();
        SetToTranslation(true);
        SetToRotation(true);
	}
	
    //---------------------------------------------------------------------------------
    // Initialize slider bars to specific function
    void SetToTranslation(bool v)
    {
        Vector3 p = ReadObjectXfrom();
        mPreviousSliderValues = p;
        X.InitSliderRange(-.5f, .5f, p.x);
        Z.InitSliderRange(-.5f, .5f, p.z);
    }

    

    void SetToRotation(bool v)
    {
        Vector3 r = ReadObjectXfrom();
        mPreviousSliderValues = r;
        Y.InitSliderRange(-180, 180, r.y);
        mPreviousSliderValues = r;
    }

    
    //---------------------------------------------------------------------------------
    // resopond to sldier bar value changes
    void XValueChanged(float v)
    {
        Vector3 p = ReadObjectXfrom();
        // if not in rotation, next two lines of work would be wasted
            float dx = v - mPreviousSliderValues.x;
            mPreviousSliderValues.x = v;
        p.x = v;
        mBodyNode.localPosition = p;
    }
    
    void YValueChanged(float v)
    {
        Vector3 p = ReadObjectXfrom();
            // if not in rotation, next two lines of work would be wasted
            float dy = v - mPreviousSliderValues.y;
            
            Quaternion q = Quaternion.AngleAxis(dy, Vector3.up);
            mBaseNode.localRotation = q;
    }

    void ZValueChanged(float v)
    {
        Vector3 p = ReadObjectXfrom();
            // if not in rotation, next two lines of work would be wasterd
            float dz = v - mPreviousSliderValues.z;
            mPreviousSliderValues.z = v;
        p.z = v;
        mBodyNode.localPosition = p;
    }
    //---------------------------------------------------------------------------------


    public void ObjectSetUI()
    {
        Vector3 p = ReadObjectXfrom();
        X.SetSliderValue(p.x);  // do not need to call back for this comes from the object
        Y.SetSliderValue(p.y);
        Z.SetSliderValue(p.z);
    }

    private Vector3 ReadObjectXfrom()
    {
        return mBodyNode.localPosition;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}