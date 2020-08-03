using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject go;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;

    //private int stepCount = 0;
    private float stepSize = 0.1f; 
    private float scaleRatioY = 1f; 
    private float maxScaleRatioY = 3f; 
    private float minScaleRatioY = 0.2f; 
    private Vector3 initScale, initPos;

    private void Start()
    {
        var transform1 = go.transform;
        initScale = transform1.localScale;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
   
        
        if (Input.GetKey("w"))
        {
            if (scaleRatioY + stepSize < maxScaleRatioY)
            {
                scaleRatioY += stepSize;
                go.transform.localScale = new Vector3(1 / scaleRatioY, scaleRatioY, initScale.z);
                rb.centerOfMass = new Vector3(0,(0 - go.transform.localScale.y ) /2,0);
            }
        }        
        
        if (Input.GetKey("s"))
        {
            if (scaleRatioY - stepSize > minScaleRatioY)
            {
                scaleRatioY -= stepSize;
                go.transform.localScale = new Vector3(1 / scaleRatioY, scaleRatioY, initScale.z);
                rb.centerOfMass = new Vector3(0,(0 - go.transform.localScale.y ) /2,0);
            }
        }

        
        
        if (Input.GetKey("d"))
        {
            rb.AddForce( sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey("a"))
        {
            rb.AddForce( -sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager3>().EndGame();
        }
    }
}