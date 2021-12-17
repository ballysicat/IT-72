using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       transform.Rotate( 0,20.1f * Time.deltaTime, 0 ); 
    }
}
