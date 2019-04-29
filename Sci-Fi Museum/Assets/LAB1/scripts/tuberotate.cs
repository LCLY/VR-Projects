using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       transform.Rotate(20 * Time.deltaTime, 0,0); //rotates 50 degrees per second around z axis
        
    }
}
