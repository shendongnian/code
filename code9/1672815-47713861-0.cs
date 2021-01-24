    public class MoveController : MonoBehaviour 
    {
    
        [SerializeField]
        private float shootVelocity=30f;
    
        Rigidbody rb;
        void Start () 
        {
            rb = GetComponent<Rigidbody>();
        }
    
        private void OnGUI()
        {
            if(GUI.Button(new Rect(0,0,100,100), "shoot"))
            {
                rb.velocity = shootVelocity * Vector3.forward;
            }
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            rb.isKinematic = true;  
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
