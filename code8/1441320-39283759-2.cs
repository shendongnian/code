    float lastHit; // Holds last time character got hit
    
    void Awake()
    {
        lastHit = Time.time;
    }
    
    void OnTriggerEnter(Collider other)
    {
        healthBar.value -= 100;//If enemy hits character loses 10 points
        lastHit = Time.time;
    }
    
    void RestoreHealth()
    {
        if(healthBar.value<100)
            healthBar.value+=2;
    }
    
    //Updateiscalledonceper frame
    void Update () {
    
        if (Time.time - lastHit > 10) // 10 seconds
    	{ 	
            RestoreHealth();
        }
    }
