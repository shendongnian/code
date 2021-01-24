    [System.Serializable]
    public struct SpinableObject
    {
        public Transform t ;
        public float rotationSpeed ;
        public float minSpeed ;
        public float maxSpeed ;
        public float speedRate;
        [HideInInspector]
        public bool slowDown ;
    }
    public class SpinObject : MonoBehaviour
    {
        private bool slowDown = false;
        public float rotationSpeed;
        public float slowdownMax;
        public float slowdownMin;
        public GameObject[] objectsToRotate;
    
        // Update is called once per frame
        void Update ()
        {
            for (int i = 0; i < objectsToRotate.Length; i++)
            {
                SpinableObject spinableObject = objectsToRotate[i]
                if (spinableObject.rotationSpeed > spinableObject.maxSpeed )
                    spinableObject.slowDown = true;
                else if (spinableObject.rotationSpeed < spinableObject.minSpeed )
                    spinableObject.slowDown = false;
    
                spinableObject.rotationSpeed = (spinableObject.slowDown) ? spinableObject.rotationSpeed - 0.1f : spinableObject.rotationSpeed + 0.1f;
                spinableObject.t.Rotate(Vector3.forward, Time.deltaTime * spinableObject.rotationSpeed);
            }
        }
    }
