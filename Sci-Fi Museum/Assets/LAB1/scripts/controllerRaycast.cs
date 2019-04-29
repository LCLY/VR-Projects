using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class controllerRaycast : MonoBehaviour
{
    //raycastScript rs = new raycastScript();
    //GameObject arc = GameObject.Find("arcreactor");
    // Start is called before the first frame update
    GameObject controller;
    public raycastScript rs;
    public SteamVR_Action_Boolean trigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    SteamVR_Behaviour_Pose trackedObj;

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
    }
    void Start()
    {
        GameObject obj = GameObject.Find("Camera"); //get access to the object that has the script
        rs = obj.GetComponent<raycastScript>(); //get the component of that object
        controller = GameObject.Find("Controller (right)");
    }
    //GameObject obj = GameObject.Find("Camera");
    //raycastScript rs = obj.GetComponent<raycastScript>();
    
    // Update is called once per frame
    void Update()
    {
        /*if (trigger.GetStateDown(trackedObj.inputSource))
        {
            Debug.Log("TRIGGERED");
        }*/
              

        if (Input.GetButton("Button.Two"))
        {
            Debug.Log("TRIGGERED");
        }

            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            /*=================== Scaling ===================*/
            if (hit.collider.gameObject.tag == "decreaseScale")
            {
                rs.shrink = true;
                Debug.Log("collided with decreaseScale");
                if (Input.GetAxis("Oculus_GearVR_RIndexTrigger") > 0)
                {
                    Debug.Log("Hit decreaseScale button!");                  
                    rs.shrink = true;
                }
            }

            if(hit.collider.gameObject.tag == "increaseScale")
            {
                rs.shrink = false;
                Debug.Log("collided with increaseScale");
                if (Input.GetAxis("Oculus_GearVR_RIndexTrigger") > 0)
                {
                    Debug.Log("Hit increaseScale button!");                   
                    rs.shrink = false;
                }               
            }
            /*=================== Scaling ===================*/

            /*=================== Rotate ===================*/
            if (hit.collider.gameObject.tag == "decreaseSpeed")
            {
                rs.decreaseSpeed();
                Debug.Log("Collided with decreaseSpeed button!");               
                if (Input.GetKey("up"))
                {
                    Debug.Log("Hit decreaseSpeed button!");
                    rs.decreaseSpeed();
                }
            }

            if(hit.collider.gameObject.tag == "increaseSpeed")
            {
                rs.increaseSpeed();
                Debug.Log("Collided with increaseSpeed button!");
                if (Input.GetKey("up"))
                {
                    Debug.Log("Hit increaseSpeed button!");
                    rs.increaseSpeed();
                }
            }
            /*=================== Rotate ===================*/

            /*=================== Transform ===================*/
            if (hit.collider.gameObject.tag == "decreaseAmplitude")
            {
                rs.decreaseAmplitude();
                Debug.Log("Collided with decrease Amplitude button!");
                if (Input.GetKey("up"))
                {
                    Debug.Log("Hit decreaseAmplitude button");
                    rs.decreaseAmplitude();
                }

            }

            if (hit.collider.gameObject.tag == "increaseAmplitude")
            {
                rs.increaseAmplitude();
                Debug.Log("Collide with increaseAmplitude button!");
                if (Input.GetKey("up"))
                {
                    Debug.Log("Hit increaseAmplitude button!");
                    rs.increaseAmplitude();
                }
            }
            /*=================== Transform ===================*/

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
