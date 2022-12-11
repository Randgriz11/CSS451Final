using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardStuff : MonoBehaviour
{


    public GameObject ourCanvas;
    // Update is called once per frame
    void Update()
    {
        keyboardStuff();
        
    }

    void keyboardStuff()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ourCanvas.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            ourCanvas.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    void switchStatement()
    {
        
    }
}
