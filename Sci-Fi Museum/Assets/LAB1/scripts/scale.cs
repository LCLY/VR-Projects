using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
{
    public float timeStop = 0.1f;   
    float timer;
    GameObject helmet;
    Vector3 center;
    Vector3 pos;

    bool reset = false;
  
    // Start is called before the first frame update
    void Start()
    {
        helmet = GameObject.Find("helmet");
    }

    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.transform.localScale.x; // relative scale factor

        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }

    private void ScaleObject()
    {
        Vector3 originalCenter = Vector3.Scale(helmet.GetComponent<Renderer>().bounds.center, helmet.transform.localScale);
        Vector3 pos = helmet.transform.position;

        float d = Vector3.Distance(helmet.transform.position, new Vector3(-0.65463f, -43.267f, 61.352f));
        float f = d / Vector3.Distance(new Vector3(-0.65463f, -43.267f, 61.352f), new Vector3(-1.467f, -28.865f, 36.348f));
        float t = 1.0f - f;

        helmet.transform.localScale = Vector3.Lerp(new Vector3(1.4724f, 1.4724f, 1.4724f), new Vector3(1f,1f,1f), t);

        Vector3 newCenter = Vector3.Scale(helmet.GetComponent<Renderer>().bounds.center, helmet.transform.localScale);
        Vector3 diff = originalCenter - newCenter;
        Vector3 scaledPos = pos + diff;

        helmet.transform.position = scaledPos;
       
    }

    void scaleFunction()
    {
        timer += Time.deltaTime;


        if (timer > timeStop)
        {
            reset = false;
            //print("timer is done");
        }
        else
        {
            if (reset == true)
            {

                helmet.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
             
            }
            else
            {
                helmet.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);              
            }

        }
    }

 
    // Update is called once per frame
    void Update()
    {
        scaleFunction();     
        //ScaleObject();
        //ScaleAround(helmet, center, new Vector3(2.936518f, 2.936518f, 2.936518f));
    }
}
