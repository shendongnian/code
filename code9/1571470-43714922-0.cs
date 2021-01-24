    public float speed;
    private Rigidbody rb;
    
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Update()
    {
        bool w = Input.GetKey(KeyCode.W);
    
        if (w)
        {
            Vector3 tempVect = new Vector3(0, 0, 1);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
    }
