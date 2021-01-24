    public float health = 150f;
    void OnCollisionEnter2D(Collision2D beam)
    {
        float damage = 0f; // current damage...
        if (beam.gameObject.tag == "Box") 
        {
            // Destroy (gameObject); // do not destroy, just remove health
            damage = health; // reduce health to 0
        }
        else
        {
            Projectile enemyship = beam.gameObject.GetComponent<Projectile> ();   
            if (enemyship) 
            {
                // Destroy (gameObject); // again do not destroy.. just reduce health
                damage = 100f;
            }
        }
        health -= damage;
        Debug.Log (health); // print your health
        // check if dead
        if (health < 0f || health == 0f) {
            Destroy (gameObject); // this line not executing
        }
    }
