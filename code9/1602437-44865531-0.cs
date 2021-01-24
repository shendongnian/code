    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour
    {
        public Vector3 localPos;
        public Vector3 worldPos;
        void Update()
        {
            worldPos = transform.TransformPoint(localPos);
        }
    }
