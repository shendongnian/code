    public Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 velocity = Vector2.zero;
    void Update()
    {
        if (Input.GetKey("w"))
        {
            velocity = Vector2.down * speed;
        }
        else {
            velocity = Vector2.zero;
        }
    }
    void FixedUpdate()
    {
        MoveBall();
    }
    void MoveBall()
    {
        rb.MovePosition(rb.position * velocity * Time.deltaTime);
    }
