	public float speed = 10.0F;
	public float RotSpeed = 150.0F;
	public float minY = 0.0f;
	public float maxY = 90.0f;
	float forwardBackward;
	float leftRight;
	float RotLeftRight;
	float RotUpDown;
	Vector3 euler;
	public void CameraRotate()
	{
		transform.localEulerAngles = euler;
		// Getting axes
		RotLeftRight = Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
		RotUpDown = Input.GetAxis("Mouse Y") * -RotSpeed * Time.deltaTime;
		// Doing movements
		euler.y += RotLeftRight;
		euler.x += RotUpDown;
		LimitRotation ();
	}
	public void LimitRotation()
	{
		if(euler.x >= maxY)
			euler.x = maxY;
		if(euler.x <= minY)
			euler.x = minY;
	}
