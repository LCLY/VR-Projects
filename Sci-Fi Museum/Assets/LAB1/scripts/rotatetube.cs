using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatetube : MonoBehaviour
{
    float speed = 5f;
    float height = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z) * height;
        transform.Rotate(0, 20 * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }
}
