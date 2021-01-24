    public float speed = 5f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
           transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
