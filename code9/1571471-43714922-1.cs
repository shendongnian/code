    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
    
        Vector3 tempVect = new Vector3(h, 0, v);
        tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + tempVect);
    }
