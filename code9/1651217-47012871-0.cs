    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Gaze_Timer : MonoBehaviour {
    
        public int gazeTime = 3; //the amount of time needed to look to teleport
        public GameObject playerCam; //the players camera
        private Vector3 startingPosition;
        private Vector3 changePosition;
    
        private bool startCoRoutine; //is the co-routine running
    
        void Start() {
            startingPosition = transform.localPosition;
            changePosition = startingPosition;
            startCoRoutine = false; //testing this out as true or false
        }
    
        void Update() {
            //...
        }
    
        // when I gaze 
        public void PointerEnter() {
            Debug.Log("I entered.");
            if (startCoRoutine) {
                StopCoroutine("waypointTimerEvent");
            } else {
                StartCoroutine("waypointTimerEvent", gazeTime);
            }
            startCoRoutine = !startCoRoutine;
        }
    
        // when I look away
        public void PointerExit() {
            Debug.Log("I exited.");
            if (startCoRoutine) {
                StopCoroutine("waypointTimerEvent");
                startCoRoutine = false;
            }
        }
    
        IEnumerator waypointTimerEvent(float waitTime) {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("I waited " + waitTime + " seconds");
            GetComponent<Renderer>().material.color = Color.blue;
            changePosition.y += 0.1f;
            transform.localPosition = changePosition;
        }
    }
