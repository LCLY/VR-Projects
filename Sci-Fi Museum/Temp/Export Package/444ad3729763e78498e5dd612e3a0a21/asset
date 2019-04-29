using UnityEngine;
using System.Collections;

public class door2 : MonoBehaviour
{
    GameObject thedoor;

    void OnTriggerEnter(Collider obj)
    {
        thedoor = GameObject.FindWithTag("Door2");
        thedoor.GetComponent<Animation>().Play("open2");
    }

    void OnTriggerExit(Collider obj)
    {
        thedoor = GameObject.FindWithTag("Door2");
        thedoor.GetComponent<Animation>().Play("close2");
    }
}