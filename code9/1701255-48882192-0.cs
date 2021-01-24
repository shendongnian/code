    float timeWalking = 1.0f;
    void Update () {
        rb.velocity = new Vector2(3, rb.velocity.y);
    
        if (Input.GetMouseButtonDown(0) && onGround)
        {
            timeWalking += Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, 3) * timeWalking;
        }
        if (Input.GetMouseButtonUp(0) && onGround)
              timeWalking = 1.0f;
    }
