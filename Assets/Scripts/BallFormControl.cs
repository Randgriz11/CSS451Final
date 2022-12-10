using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallFormControl : MonoBehaviour
{

    public SliderWithEcho ballPower;
    public static float power;
    public Dropdown ballDropDown;
    public GameObject golfball, basketball, bowlingBall;
    private Vector3 previousPosition;
    public Button swingButton;
    public Transform arms;
    private float v;
    public CanvasGroup ourCanvas;
    public GameObject clubHead;
    private bool downswingBool;
    private bool upSwingBool;
    // Start is called before the first frame update
    void Start()
    {
        downswingBool = false;
        swingButton.onClick.AddListener(swing);
        power = 5;
        SetPower(true);
        ballPower.SetSliderListener(powerValueChanged);
        ballDropDown.onValueChanged.AddListener(BallSelection);
        previousPosition = bowlingBall.transform.localPosition;
    }

    // Update is called once per frame
        void Update()
        {
            downSing();
            contact();
            
        }

        public void contact()
        {
            // if (clubHead.transform.localPosition == golfball.transform.localPosition)
            // {
            //     Debug.Log("Woosh");
            // }

           
        }
        
        

        public void downSing()
        {
            
            if (upSwingBool == true)
            {
                ourCanvas.interactable = false;
                
                Quaternion q = Quaternion.AngleAxis(v, Vector3.right);
                arms.transform.localRotation = q;
                v += 90f * Time.smoothDeltaTime;
                if (v >= 90)
                {
                    upSwingBool = false;
                    downswingBool = true;
                }
            }
            
            
            if (downswingBool == true)
            { 
                Quaternion q = Quaternion.AngleAxis(v, Vector3.right);
                //Vector3 q = new Vector3(v, 0, 0);
                arms.transform.localRotation = q;
                v -= 90f * Time.smoothDeltaTime;
                if (v <= -90)
                {
                    downswingBool = false;
                     arms.localRotation = Quaternion.identity;
                     v = 0;
                     ourCanvas.interactable = true;
                }
            }
        }

        public void swing()
        {
            
            upSwingBool = true;
            
        }
        void BallSelection(int index)
        {
            switch (index)
            {
                case 0:
                    
                    
                case 1:
                    basketball.SetActive(false);
                    bowlingBall.SetActive(false);
                    golfball.SetActive(true);
                    golfball.transform.localPosition = previousPosition + new Vector3(0f,-.35f,0f);
                    index = 0;
                    break;
                    
                case 2:
                    
                    bowlingBall.SetActive(false);
                    golfball.SetActive(false);
                    basketball.SetActive(true);
                    golfball.transform.localPosition = previousPosition;
                    index = 0;
                    break;
                case 3:
                   
                    golfball.SetActive(false);
                    basketball.SetActive(false);
                    bowlingBall.SetActive(true);
                    golfball.transform.localPosition = previousPosition;
                    index = 0;
                    break;
            }
        }

        void powerValueChanged(float v)
        {
            power = v;
        }
        void SetPower(bool v)
        {
            ballPower.InitSliderRange(.5f, 10f, power);
            
        }
        

    
}