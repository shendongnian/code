    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class WHEELSPIN : MonoBehaviour {
    HingeJoint hinge;
    JointMotor motorz;
    
    private void Update()
     {
        hinge = GetComponent<HingeJoint>();
        motorz = hinge.motor;
        hinge.useMotor = true;
       
        motorz.freeSpin = true;
        if (Input.GetAxis("Vertical"))
        {
            motorz.force = 1000;
            motorz.targetVelocity = 900;
        }
    }
    }
