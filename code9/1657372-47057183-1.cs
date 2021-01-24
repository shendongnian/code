    public float speed = 100;
    public Rigidbody2D rb;
    
    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
    
        //Move only if we actually pressed something
        if ((h > 0 || v > 0) || (h < 0 || v < 0))
        {
            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
    
            //rb.MovePosition(rb.transform.position + tempVect);
    
            Vector3 newPos = rb.transform.position + tempVect;
            checkBoundary(newPos);
        }
    }
    
    void checkBoundary(Vector3 newPos)
    {
        //Convert to camera view point
        Vector3 camViewPoint = Camera.main.WorldToViewportPoint(newPos);
    
        //Apply limit
        camViewPoint.x = Mathf.Clamp(camViewPoint.x, 0.04f, 0.96f);
        camViewPoint.y = Mathf.Clamp(camViewPoint.y, 0.07f, 0.93f);
    
        //Convert to world point then apply result to the target object
        Vector3 finalPos = Camera.main.ViewportToWorldPoint(camViewPoint);
        rb.MovePosition(finalPos);
    }
