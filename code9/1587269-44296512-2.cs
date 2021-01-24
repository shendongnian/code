    public Rigidbody myPrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate and Addforce on one line
            Instantiate(myPrefab).AddForce(new Vector3(0, 500, 0));
        }
    }
