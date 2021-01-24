    	void Update()
	{   
        Movement();
    }
    void Movement()
    {
        physicPlayer.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -moveRangeX)
            physicPlayer.velocity = new Vector2(-moveSpeed, physicPlayer.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= moveRangeX)
            physicPlayer.velocity = new Vector2(moveSpeed, physicPlayer.velocity.y);
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= moveRangeY)
            physicPlayer.velocity = new Vector2(physicPlayer.velocity.x, moveSpeed);
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -moveRangeY)
            physicPlayer.velocity = new Vector2(physicPlayer.velocity.x, -moveSpeed);
    }
