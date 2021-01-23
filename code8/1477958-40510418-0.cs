    public class rotationAnimation : MonoBehaviour
    {
        public float rotationDuration = 120; // 2 minutes max
        private float rotationStartTime ;
    
        // Use this for initialization
        void Start ()
        {
            rotationStartTime = Time.time ;
        }
    
        // Update is called once per frame
        void Update ()
        {
            if( Time.time - rotationStartTime < rotationDuration ) 
            {
                float translation = Time.deltaTime * 30;
                transform.Rotate (Vector3.up, translation, Space.World);
            }
        }
    }
