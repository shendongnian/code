    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TouchMover : MonoBehaviour {
    	
    	private float _speed;
    	private Dictionary<int,Func<Touch, Vector3>> _touchFuncDict; 
    
    	void Awake(){
    		_touchFuncDict = new Dictionary<int,Func<Touch, Vector3>>();
    	}
    
    	void Update(){
    		//Clean _touchFuncDict of any functions that reference a touch that is not active
		   int[] touchIds = (int[])Input.touches.Select( x => x.fingerId);
		   var keysToRemove = _touchFuncDict.Keys.Except(touchIds).ToList();
		   foreach (var key in keysToRemove)
		       _touchFuncDict.Remove(key);
    
    		// Iterate through touches, and evaluate it's associate GetTouchVelocity function.
    		// If we haven't created a function for it yet, then do so;
    		foreach (var touch in Input.touches){
    			Func<Touch,Vector3> getTouchVelocity = null;
    			if (!_touchFuncDict.TryGetValue(touch.fingerId, out getTouchVelocity)){
    				getTouchVelocity = GenerateTouchVelocityFunc(30);
    				_touchFuncDict.Add(touch.fingerId,getTouchVelocity);
    			}
    			transform.position = transform.position + getTouchVelocity(touch) * _speed * Time.deltaTime;
    		}
    	}
    
    	// Generates a function that requires a Touch parameter and will return a Vector3
    	Func<Touch, Vector3> GenerateTouchVelocityFunc(int buffer){
    		Vector2 startPos = Vector2.zero;
    		Vector2 moveDelta = Vector2.zero;
    		Vector3 desiredVelocity = Vector3.zero;
    
    		Func<Touch, Vector3> getTouchVelocity = delegate(Touch touch){
    			switch(touch.phase){
    				case TouchPhase.Began:
    					startPos = touch.position;
    				break;
    				case TouchPhase.Moved:
    					moveDelta = touch.position - startPos;
    				break;
    				case TouchPhase.Ended:
    					if (moveDelta.magnitude > buffer){
    						desiredVelocity = new Vector3(moveDelta.x,0,moveDelta.y).normalized;
    					} else {
                           // this is your move forward on tap;
                           desiredVelocity = new Vector3(0,0,1);
                        }
    				break;
    			}
    			return desiredVelocity;
    		};	
    		return getTouchVelocity;
    	}
    
    }
