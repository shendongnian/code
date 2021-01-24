    public Rigidbody2D ball;
    void Start()
    {
       ball = ball.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball") {
            ball.AddForce(Vector2.left * 1000f);
            Debug.Log("ABC");
        }
    }
}
