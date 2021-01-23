    public float MinY = 1.5f; // y position of start point
    public float MaxY = 10f; // y position of end point
    public float PingPongTime = 1f; // how much time to wait before reverse
    public Rigidbody rb; // reference to the rigidbody
    void Update()
    {
         //get a value between 0 and 1
         float normalizedTime = Mathf.PingPong(Time.time, PingPongTime) / PingPongTime;
         //then multiply it by the delta between start and end point, and add start point to the result
         float yPosition = normalizedTime * (MaxY - MinY) + MinY;
         //finally update position using rigidbody 
         rb.MovePosition(new Vector3(rb.position.x, yPosition, rb.position.z));
    }
