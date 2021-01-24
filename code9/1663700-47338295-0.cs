    bool damageable;
    
    void Update()
    {
            if (!playerController.isInvicible && damageable) 
            {
                 // damage, knockback, etc the player here;
                 damageable = false; // reset so player isn't continuously damageable
            }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player")) 
            damageable = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player")) 
            damageable = false;
    }
