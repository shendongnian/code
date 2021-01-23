    public float speed;
    public Rigidbody rb;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() 
    {
        if (Input.touchCount > 0 &&
            Input.GetTouch(0).phase == TouchPhase.Ended || (Input.GetMouseButtonDown(0)))
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * speed);
        }
    }
