    bool fast;
    Rigidbody rgd;
    float speed;
    private void Start ()
    {
        rgd = gameObject.GetComponent<Rigidbody>();
    }
	
	private void Update ()
    {
        var vel = rgd.velocity;
        speed = vel.magnitude;
        if (speed >= 2)
        {
            rgd.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
        else
        {
            rgd.collisionDetectionMode = CollisionDetectionMode.Discrete;
        }
    }
