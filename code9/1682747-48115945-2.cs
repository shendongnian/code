    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class WHEELSPIN : MonoBehaviour 
    {
    
    	HingeJoint hinge;
    	JointMotor motorz;
    
        private void Awake()
        {
            hinge = GetComponent<HingeJoint>();
        }
    	private void Update() 
    	{
    		
    		motorz = hinge.motor;
    		hinge.useMotor = true;
    
    		motorz.freeSpin = true;
    		if (Input.GetAxis("Vertical") > 0f) 
    		{
    			motorz.force = 1000;
    			motorz.targetVelocity = 900;
    		}
    	}
    }
