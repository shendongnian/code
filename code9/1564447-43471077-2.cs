    public float speed = 2f;
    Rigidbody2D rg2d;
    
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }
    
    
    void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
    
        Vector2 tempVect = new Vector2(h, v);
        tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;
        rg2d.MovePosition((Vector2)transform.position + tempVect);
    }
