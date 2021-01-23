    public class MovePlayer : MonoBehaviour
    {
        private Vector3 newPos;
        private Vector3 up = new Vector3(0, .3f, 0);
        private bool jumping = false;
        public Rigidbody rigidbody;
    
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    
        void Update()
        {
            rigidbody.freezeRotation = true;
    
            if (!jumping)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    newPos = Vector3.forward + transform.position;
                    rigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));
                    rigidbody.MovePosition(newPos);
                    rigidbody.MovePosition(newPos + up);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    newPos = Vector3.back + transform.position;
                    rigidbody.MoveRotation(Quaternion.Euler(0, 180, 0));
                    rigidbody.MovePosition(newPos);
                    rigidbody.MovePosition(newPos + up);
                }
    
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    newPos = Vector3.right + transform.position;
                    rigidbody.MoveRotation(Quaternion.Euler(0, 90, 0));
                    rigidbody.MovePosition(newPos);
                    rigidbody.MovePosition(newPos + up);
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    newPos = Vector3.left + transform.position;
                    rigidbody.MoveRotation(Quaternion.Euler(0, -90, 0));
                    rigidbody.MovePosition(newPos);
                    rigidbody.MovePosition(newPos + up);
                }
            }
        }
    
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
                jumping = false;
        }
    
        void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
                jumping = true;
        }
    }
