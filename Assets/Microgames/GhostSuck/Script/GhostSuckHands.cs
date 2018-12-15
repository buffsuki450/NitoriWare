﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSuckHands : MonoBehaviour {


    public float motorSpeedMult;
    

    public Transform tail;
    public HingeJoint2D joint;
    [SerializeField]
    private float jointmodmin, jointmodmax, jointmodangularmin, jointmodangularmax;
  
    

    private Vector3 lastMousePosition;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        updateBodyRotation();

        lastMousePosition = transform.position;
    }
        void updateBodyRotation()
    {
        float speed = (transform.position.x - lastMousePosition.x) / Time.deltaTime;
        //	, angle = body.localRotation.eulerAngles.z;
        //if (angle > 180f)
        //	angle -= 360f;
        //angle *= -1f;
       
        float zRotation = tail.transform.eulerAngles.z + (-1f * speed * motorSpeedMult * Time.deltaTime);
        if (zRotation > 180f)
            zRotation -= 360f;
        zRotation = Mathf.Clamp(zRotation, joint.limits.min + jointmodmin + jointmodangularmin * zRotation, joint.limits.max + jointmodmax + jointmodangularmax * zRotation);
        if (zRotation < 0f)
            zRotation += 360f;
        tail.transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        
    }
   
}
