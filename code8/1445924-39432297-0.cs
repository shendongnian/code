    public class move : MonoBehaviour
    {
        private float speed = 3.0f;
    
        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }
    
        public float GetSpeed()
        {
            return speed;
        }
    
        // Use this for initialization
        void Start ()
        {
            ...
        }
    
        // Update is called once per frame
        void Update ()
        {
            ...
        }
    }
