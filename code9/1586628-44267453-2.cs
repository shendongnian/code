    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float bonusDuration = 2.0f;   
    private float endBonusTime = 0 ;
    void FixedUpdate()
    {   
        if ( endBonusTime < Time.time )
        {
            if( Input.GetKeyDown("q") )
                endBonusTime = Time.time + bonusDuration ;
            else   
               rb.AddForce(0, 0, forwardForce * Time.deltaTime);            
        }
        if (endBonusTime >= Time.time ) // Don't put "else if"
        {
            rb.AddForce(0, 0, 500f * Time.deltaTime);
        }
    }
