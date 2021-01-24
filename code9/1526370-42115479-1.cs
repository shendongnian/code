    void OnCollisionEnter2D(Collision2D coll)
    {
        moveUp = !moveUp;
        if (moveUp)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed,  GetComponent<Rigidbody2D>().velocity.x);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.x);
        }
    }
