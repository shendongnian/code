    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Wrld;
    using Wrld.Space;
    
    public class focus_drone : MonoBehaviour {
        public Text drone_input; 
        public Transform target;
        private Camera cameraX;
        
        void Start()
        {
       string drone_id = drone_input.text.ToString();
       target = GameObject.Find(drone_id).transform;
       transform.LookAt(target); 
       
        }
    
        void Update()
        {
            string drone_id = drone_input.text.ToString();
            // Rotate the camera every frame so it keeps looking at the target
            target = GameObject.Find(drone_id).transform;
            transform.LookAt(target);
            var destLocation = LatLong.FromDegrees(13.746863, 100.538847);
            Api.Instance.CameraApi.AnimateTo(destLocation, distanceFromInterest: 30, headingDegrees: 0, transitionDuration: 0.5, jumpIfFarAway: false);
        }
    }
