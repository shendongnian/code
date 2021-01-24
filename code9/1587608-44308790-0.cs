    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class AvatarPingPong : MonoBehaviour {
        // Use this for initialization
        public float speed;
        public float startXCord, endXCord;
        float endTrunx, startTurnx;
        public GameObject obj;
        Vector3 EndPoint, StartPoint;
        //I'm going to assume you start it moving left. You may have to change this
        bool goingLeft = false;
        void Start () {
            EndPoint = transform.position;
            endXCord = EndPoint.x;
            endTrunx = EndPoint.x - 2f;
    
            StartPoint = transform.position;
            StartPoint.x = startXCord;
            startTurnx = StartPoint.x + 2f;
        }
    
    
        // Update is called once per frame
        void Update () {
            float prevX = transform.position.x;
            float newX = PingPong (Time.time * speed, startXCord, endXCord );
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    
            if (newX > prevX) {
                //avatar is moving to the right, check to see if that's the direction it was going last Update
                if (goingLeft) {
                    Debug.Log("Flipping Right");
                    obj.transform.Rotate(0f, 180f, 0f);
                    goingLeft = false;
                }
            }else if (newX < prevX){
                //avatar is moving to the left, check to see it that's the direction it was going last Update
                if (!goingLeft) {
                    Debug.Log("Flipping Left");
                    obj.transform.Rotate(0f, 180f, 0f);
                    goingLeft = true;
                }
            }
    
        }
        //function to change the default starting value of (0, 0, 0) to any value
        float PingPong(float t, float minLength, float maxLength) {
            return Mathf.PingPong(t, maxLength-minLength) + minLength;
        }   
    }
