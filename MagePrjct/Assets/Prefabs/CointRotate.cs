using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointRotate : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
       transform.Rotate( 0, 0, 15.1f * Time.deltaTime); 
    }
}
