    public class RealBallMove : MonoBehaviour {
        public float speed;
        public Rigidbody rb;
        private bool thrown ;
        void Start() 
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update() 
        {
            if (
                !thrown && (
                (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended ) ||
                Input.GetMouseButtonDown(0) )
            )
            {
                rb.isKinematic = false;
                rb.AddForce (new Vector3(0.0f, 20.0f, 12.0f));
                thrown = true ;
            }
        }
    }
