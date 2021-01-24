    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class OscilateObs : MonoBehaviour {
        // internal class where all gameobjects and their startposition will be saved
        internal class OscGameObjects
        {
            public GameObject gameObject;
            public Vector3 startPosition;
        }
        // Here the information of all gameObjects stored in a list
        private List<OscGameObjects> objectList;
        public float updateSpeed = 0.05f;
        public float oscScalar = 2f;
        public enum OscillationFunction {
            Sine = 1
        }
    
        void Start () {
            // First, the gameobjects have to saved to our internal List
            InitializeOscGameObjects();
            // Start the Corotine
            StartCoroutine(Oscillate(OscillationFunction.Sine, oscScalar));
        }
        private void InitializeOscGameObjects()
        {
            var objects = GameObject.FindGameObjectsWithTag("MovingObs2");
            objectList = new List<OscGameObjects>();
            foreach (var o in objects)
            {
                var oscObject = new OscGameObjects();
                oscObject.gameObject = o;
                oscObject.startPosition = o.transform.position;
                objectList.Add(oscObject);
            }
        }
        public IEnumerator Oscillate(OscillationFunction method, float scalar)
        {
            // Loop forever
            while(true)
            {
                foreach (var element in objectList)
                {
                    var currentPosition = element.gameObject.transform.position;
                    currentPosition.x = element.startPosition.x + Mathf.Cos(Time.time) * scalar;
                    element.gameObject.transform.position = currentPosition;
                }
                yield return new WaitForSeconds(updateSpeed);
            }
        
        }
    }
