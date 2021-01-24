    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Zero out the ball's velocity
        rb2d.velocity = Vector2.zero;
    
        //Freeze constraints
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    
        // If the ball collides with something set it to dead...
        isDead = true;
        //...and tell the game control about it.
        GameController.instance.PlayerDied();
    }
