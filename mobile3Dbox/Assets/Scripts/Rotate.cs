using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    bool rotate = false;

    // Update is called once per frame
    void Update()
    {
        
        if(rotate == false)
            transform.Rotate(0,0,0);
        else
            transform.Rotate(0,Time.deltaTime * 20,0);
    }
    void OnMouseDown(){
        // this object was clicked - do something
       
        if(rotate == false)
            rotate = true;
        else
            rotate = false;
    }


}
