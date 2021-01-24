    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float jumpHeight;
        Rigidbody2D rb;
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
    
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
    
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
    }
