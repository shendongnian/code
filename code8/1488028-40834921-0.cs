    float playerAngle = 0;  // the angular position of the player
    float playerSpeed = 0.5;  // the linear speed of the player
    float radius = 1;  // the radius of the circle
    void Update()
    {
        playerAngle += Input.GetAxis("Horizontal") * Time.deltaTime * speed / radius;
        float x = radius * Mathf.Cos( playerAngle ) ;
        float y = radius * Mathf.Sin( playerAngle ) + 6;
        float z = 0;
        transform.position = new Vector3(x, y, z);
    }
