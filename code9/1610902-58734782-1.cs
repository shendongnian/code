        // If the entering collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }
    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }
    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack ();
        }
        // If the player has zero or less health...
        if(playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger ("PlayerDead");
        }
    }
    void Attack ()
    {
        // Reset the timer.
        timer = 0f;
        // If the player has health to lose...
        if(playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
 
