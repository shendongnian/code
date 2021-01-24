    // The position of the ball will be stored here.
    public Vector3 ballPosition;
    // Where the ball should start/go back to if it falls.
    public Vector3 startPosition;
    void Start() {
        ballPosition = ball.tranform.position;  // Assign the ball position here.
        startPosition = new Vector3(x, y, z);  // Replace x, y, z with your start co-ordinates.
    }
    // If the ball collides with the lower plane, position it at the Start Position.
    void OnCollisionEnter(Collision collision) {
       ballPosition = startPosition;
    }
