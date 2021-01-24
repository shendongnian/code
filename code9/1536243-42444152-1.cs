    using UnityEngine;
    using System.Collections;
    public class ExampleClass : MonoBehaviour {
        private GameObject cabinet;
        void Start() {
            //find the cabinet object in your scene
            cabinet = GameObject.Find("Cabinet");
        }
    }
