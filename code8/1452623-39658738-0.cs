    public float maxSpeed = 10f;
    public float jumForce = 700f;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGrounded;
    bool grounded = false;
    
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGrounded)
        
        float move = Input.GetAxis("Horizontal");
        
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
    }
    
    void Update()
    {
        if(grounded &&  Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
    }
