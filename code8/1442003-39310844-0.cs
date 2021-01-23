    bool isGrounded = false;
    public Transform GroundCheck1; // Put the prefab of the ground here
    public LayerMask groundLayer; // Insert the layer here.
     
    void Update() {
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer); 
        // checks if you are within 0.15 position in the Y of the ground
    }
