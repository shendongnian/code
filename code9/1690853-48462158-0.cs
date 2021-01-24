    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GoogleARCore.HelloAR;
    
    public class RaycastCatchObject : MonoBehaviour
    {
        private GameObject childObject;
        public ExampleARController helloAr;
        public enum HoverState { HOVER, NONE };
        public HoverState hover_state = HoverState.NONE;
    
        private void Start()
        {
            helloAr._ShowAndroidToastMessage("Awake");
        }
    
        //Update is called once per frame
        public void FixedUpdate()
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
    
            RaycastHit hit;
    
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                if (hover_state == HoverState.NONE && hit.transform.tag == "gameObjectCollider") //if gamertag
                {
                    helloAr._ShowAndroidToastMessage("In");
                    hover_state = HoverState.HOVER;
                }
                else if (hover_state == HoverState.HOVER && hit.transform.tag != "gameObjectCollider")
                {
                    helloAr._ShowAndroidToastMessage("Out");
                    hover_state = HoverState.NONE;
                }
            }
            else
            {
                if (hover_state == HoverState.HOVER) //if gamertag
                {
                    helloAr._ShowAndroidToastMessage("Out");
                    hover_state = HoverState.NONE;
                }
            }
        }
    }
