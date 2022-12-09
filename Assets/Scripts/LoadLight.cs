using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLight : MonoBehaviour
{
    public Transform LightPosition;

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("LightPosition", LightPosition.localPosition);
    }
}
