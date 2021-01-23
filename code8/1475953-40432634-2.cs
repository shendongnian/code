	Vector3 velocity = Vector3.zero;
	if (transform.rotation.x < -10)
	{
		//do no forward or backward movement
		Debug.Log("Rotation too great to forward move...");
		tooGoodForMovement = true;
	}
	else
	{
		tooGoodForMovement = false;
		if (Input.GetKey(KeyCode.W))
		{
			//Forward
			velocity = (camera.forward * moveSpeed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			//Back
			velocity = (-camera.forward * moveSpeed);
		}
	}
	if (Input.GetKey(KeyCode.A))
	{
		//Left
		velocity = -camera.right * moveSpeed;
	}
	if (Input.GetKey(KeyCode.D))
	{
		//Right
		velocity = camera.right * moveSpeed;
	}
	velocity.Y = 0;
	player.velocity = velocity;
