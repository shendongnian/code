    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class zoomIN : MonoBehaviour {
    
    	public Camera cam;
        private bool _zoomedIn = false;
        private int _zoomedInTarget = 60;
        private int _zoomedOutTarget = 20;
    
    	// Update is called once per frame
    	void Update () {
    
    		if (Input.GetMouseButtonDown (1))
                _zoomedIn = true;
    
    		if (Input.GetMouseButtonUp (1)) {
                _zoomedIn = false;
    		}
    		
            if (_zoomedIn) {
                if (cam.fieldOfView < _zoomedInTarget)
                    cam.fieldOfView += 5;
            } else {
                if (cam.fieldOfView > _zoomedOutTarget)
                    cam.fieldOfView -= 5;
            }
    	}
