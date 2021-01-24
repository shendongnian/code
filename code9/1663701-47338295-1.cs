    bool damageable;
    
    void Update()
    {
            if (!playerController.isInvicible && damageable) 
            {
                 // damage, knockback, etc the player here;
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
            damageable = false; // player is still damageable unless he leaves spikes
    }
