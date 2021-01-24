    using System.Collections.Generic;
    using UnityEngine;
    
    [System.Serializable]
    public class SpinableObject
    {
        public Transform t;
        public float rotationSpeed;
        public float minSpeed;
        public float maxSpeed;
        public float speedRate;
        public bool slowDown;
    
        public void RotateObject()
        {
            if (rotationSpeed > maxSpeed)
                slowDown = true;
            else if (rotationSpeed < minSpeed)
                slowDown = false;
    
            rotationSpeed = (slowDown) ? rotationSpeed - 0.1f : rotationSpeed + 0.1f;
            t.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        }
    }
    public class SpinObject : MonoBehaviour
    {
        [SerializeField]
        private SpinableObject[] objectsToRotate;
    
        // Update is called once per frame
        void Update()
        {
            foreach(var spinner in objectsToRotate)
                spinner.RotateObject();
        }
    }
