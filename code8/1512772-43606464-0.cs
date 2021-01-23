    public class fallBridge : MonoBehaviour {
    
        private Rigidbody ball;
        public GameObject bridgePivot;
        public float rotateDuration = 2; // Time in seconds
        // When you begin rotating you fill these three variables
        private float startTime;
        private Vector3 from;
        private bool rotating = false;
        // If the target doesn't change you might as well define it beforehand
        private Vector3 to = new Vector3 (0, 0, -85);
    
        void Update () {
            if (rotating) {
                float t = (Time.time - startTime) / rotateDuration;
                if (t < 1) {
                    bridgePivot.transform.eulerAngles = Vector3.Lerp (from, to, t);
                } else {
                    bridgePivot.transform.eulerAngles = to;
                    rotating = false;
                }
            }
        }
    
        void OnCollisionEnter(Collision other)
        {
            ball = GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ();
            if (other.gameObject.tag == "Player" && ball.transform.localScale == new Vector3(2.0f,2.0f,2.0f)) {
                Debug.Log("ENTER");
                startTime = Time.time; // Begin now
                from = bridgePivot.transform.eulerAngles; // Remember the start position
                rotating = true; // Signal to start rotating
            }
        }
    }
