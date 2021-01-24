	void Update()
    {
        rbody.velocity = rbody.velocity * .9f; // custom friction
        if (Input.GetKey(KeyCode.W))
            rbody.AddForce(Vector2.up * speed);
        if (Input.GetKey(KeyCode.S))
            rbody.AddForce(Vector2.down * speed);
        // repeat for A and D
	}
