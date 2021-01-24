     void Start () 
        {
            rb2D = GetComponent<Rigidbody2D> ();
            speed = 4;
            maxSpeed = 0.01f;
        }
    
        void Update () 
        {
            if(Input.GetKey(KeyCode.W))
            {
                rb2D.AddForce (Vector3.up * speed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                rb2D.AddForce (-Vector3.up * speed);
            }
            if(Input.GetKey(KeyCode.D))
            {
                rb2D.AddForce (Vector3.right * speed);
            }
            if(Input.GetKey(KeyCode.A))
            {
                rb2D.AddForce (-Vector3.right * speed);
            }
        }
    
        void FixedUpdate ()
        {
            if(rb2D.velocity.magnitude > maxSpeed)
            {
                rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
            }
        }
    }
