using UnityEngine;

// C# example.

public class raycastScript : MonoBehaviour
{
    //public float timeStop = 0.1f;
    float timer;
    public GameObject arc;
    GameObject ironman;
    GameObject tube;
    GameObject thanos;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 0.3f;
    public float rotateSpeed = 20;
    public float width = 0.01f;
    public float height = 0.01f;
    public float length = 0.01f;
    
    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
       
    public bool shrink = false;   

    // Start is called before the first frame update
    void Start()
    {
       
        arc = GameObject.Find("arcreactor");       
        ironman = GameObject.Find("ironman");
        tube = GameObject.Find("tube");
        thanos = GameObject.Find("thanos");
        posOffset = thanos.transform.position; //get the position of the object
    }

    public void increaseSpeed()
    {   if(rotateSpeed <= 0)
        {
            rotateSpeed = 5;
        }
        else
        {
            rotateSpeed += 5;
        }
        
    }

    public void decreaseSpeed()
    {
        if(rotateSpeed > 0)
        {
            rotateSpeed -= 5;
        }
        else
        {
            rotateSpeed = 0;
        }
    }

    public void increaseAmplitude()
    {
        if(amplitude > 2)
        {
            amplitude = 2;
        }
        else
        {
            amplitude += 0.1f;
        }
    }

    public void decreaseAmplitude()
    {
        if(amplitude <= 0)
        {
            amplitude = 0;
        }
        else
        {
            amplitude -= 0.05f;

        }
    }


    void rotateFunction()
    {              
        ironman.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
        tube.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }

    void scaleFunction()
    {
        timer += Time.deltaTime;                         
        
        if (shrink == true)
            {
            arc.transform.localScale -= new Vector3(width, height, length);
            }
        else
            {
            arc.transform.localScale += new Vector3(width, height, length);
        }

        
    }

    void transformFunction()
    {        
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        thanos.transform.position = tempPos;
    }

    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        //Debug.Log("Scale: " + arcRender.bounds.size);

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(hit.collider.gameObject.tag == "arc")
            {
                Debug.Log("Hit arc!");
                Debug.Log("Inside raycastScript the value of SHRINK is: " + shrink);
                scaleFunction();               
            }

            if(hit.collider.gameObject.tag == "ironman")
            {
                Debug.Log("Hit ironman!");
                Debug.Log("The rotate speed is now " + rotateSpeed);
                rotateFunction();
            }

            if(hit.collider.gameObject.tag == "chair")
            {
                Debug.Log("Hit thanos!");
                Debug.Log("The amplitude is now " + amplitude);
                transformFunction();
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }

       
       

    }


}

