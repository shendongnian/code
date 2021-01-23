    void Movement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5 && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
    }
