    public Rigidbody myPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = Instantiate(myPrefab) as Rigidbody;
            rb.AddForce(new Vector3(0, 500, 0));
        }
    }
