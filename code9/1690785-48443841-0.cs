    public float speed;
    public GameObject player;
    Vector3 directionVector;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Input.mousePosition is already in pixel coordinates so the z should already be 0.
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Now that the mouse is a world position lets set his z to the same as the player
            mouseWorldPosition.z = player.transform.position.z;
            // Gives us a direction from the mouse to the player.  So think of it as Player <- Mouse remove the < and you have the equation
            directionVector = player.transform.position - mouseWorldPosition;
        }
        else
        {
            directionVector = Vector3.zero;
        }
    }
    // Physics based movement should be done in FixedUpdate
    private void FixedUpdate()
    {
            player.GetComponent<Rigidbody2D>().AddForce(directionVector.normalized * speed);
    }
