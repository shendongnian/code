    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Test");
            Player.AddForce(transform.up * 1000);
        }
    }
