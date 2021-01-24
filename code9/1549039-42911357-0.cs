    bool isGrounded = true;
    
    private float jumpForce = 2f;
    private Rigidbody2D myRigidBody2D;
    
    void Start()
    {
    
        myRigidBody2D = GetComponent<Rigidbody2D>();
    
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidBody2D.AddForce(new Vector2(0, jumpForce));
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
