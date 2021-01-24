    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Lean.Touch;
    
    public class CameraOrbit : TopClass
    {
    	[Tooltip("Ignore fingers with StartedOverGui?")]
    	public bool ignoreGuiFingers = true;
    
    	[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
    	public int requiredFingerCount = 0;
    
    	[Tooltip("The sensitivity of the movement, use -1 to invert")]
    	public float sensitivity = 0.25f;
    
    	public float min = 45f;
    	public float max = 315f;
    
    	public Vector3 target = Vector3.zero; //this is the center of the scene, you can use any point here
    
    	protected void LateUpdate()
    	{
    		// Get the fingers we want to use
    		List<LeanFinger> fingers = LeanTouch.GetFingers(ignoreGuiFingers, requiredFingerCount);
    
    		// Get the world delta of all the fingers
    		Vector2 delta = LeanGesture.GetScaledDelta(fingers);
    
    		transform.RotateAround(target, Vector3.up, delta.x * sensitivity);
    		transform.RotateAround(target, Vector3.right, delta.y * sensitivity);
    
    		Vector3 angles = transform.eulerAngles;
    		angles.x = Mathf.Clamp(angles.x, min, max);
    		angles.y = Mathf.Clamp(angles.y, min, max);
    		angles.z = 0;
    		transform.eulerAngles = angles;
    
    		transform.LookAt(target);
    	}
    }
