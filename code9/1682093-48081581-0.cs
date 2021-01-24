	void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rbody.velocity = Vector2.up * speed;
        else if (Input.GetKey(KeyCode.S))
            rbody.velocity = Vector2.down * speed;
        // repeat for A and D
        else
            rbody.velocity = rbody.velocity * .9f; // custom friction
	}
