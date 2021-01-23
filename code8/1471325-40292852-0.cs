    float reInitializeLifeOfObject = 5.0f;
    float lifeTimeOfObject = 3f;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }
    void FixedUpdate()
    {
        // This will destroy the gameObject in 5 second
        if((Time.time - startTime) > lifeTimeOfObject)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            // Re-initializing the startTime so that Object is not abruptly destroy while ball is still
            // interacting with game object
            startTime = Time.time;
        }
    }
	
