    bool isGrounded = true;
    
    private float jumpForce = 2f;
    private Rigidbody pRigidBody;
    
    void Start()
    {
        pRigidBody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            pRigidBody.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
