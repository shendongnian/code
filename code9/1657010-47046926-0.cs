    public Rigidbody InverseJoint;
    
    bool collisionStay = false;
    Collision collision = null;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
        collisionStay = true;
        this.collision = collision;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
        collisionStay = false;
        this.collision = collision;
    }
    
    void Update()
    {
        if (collisionStay)
        {
            InverseJoint.AddForce(-(collision.rigidbody.mass * Physics.gravity));
            Debug.Log("Stay");
        }
    }
