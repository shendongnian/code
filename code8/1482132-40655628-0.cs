    void Update()
    {
        //Rotation
        float rotLeftRight = Input.GetAxis("Mouse X");
        //transform.Rotate(0, rotLeftRight, 0);
        verticalRotation = Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        //Only add the rotation when both values are set so you don't overwrite the first one.
        transform.Rotate(-verticalRotation, rotLeftRight, 0);
        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        CharacterController cc = GetComponent<CharacterController>();
        cc.SimpleMove(speed);
    }
