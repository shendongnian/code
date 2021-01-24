    [System.Serializable]
    public class SpinableObject
    {
        [SerializeField]
        private Transform t ;
        [SerializeField]
        private float rotationSpeed ;
        [SerializeField]
        private float minSpeed ;
        [SerializeField]
        private float maxSpeed ;
        [SerializeField]
        private float speedRate;
        private bool slowDown ;
        public void Rotate()
        {
            if (rotationSpeed > maxSpeed )
                slowDown = true;
            else if (rotationSpeed < minSpeed )
               slowDown = false;
    
            rotationSpeed = (slowDown) ? rotationSpeed - 0.1f : rotationSpeed + 0.1f;
            t.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        }
    }
    public class SpinObject : MonoBehaviour
    {
        private bool slowDown = false;
        public float rotationSpeed;
        public float slowdownMax;
        public float slowdownMin;
        public SpinableObject[] objectsToRotate;
    
        // Update is called once per frame
        void Update ()
        {
            for (int i = 0; i < objectsToRotate.Length; i++)
            {
                objectsToRotate[i].Rotate();
            }
        }
    }
