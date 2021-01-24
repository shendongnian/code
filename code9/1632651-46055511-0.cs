    public void OnCollisionEnter (Collision collisionInfo)
    {
        // We check if the object we collided with has a tag called "Obstacle".
        if (collisionInfo.collider.tag == "Obstacle")
        {          
            movement.enabled = false;   // Disable the players movement.
            y = false;
            collisionInfo.gameObject.GetComponent<ParticleSystem>().Play(); // play the explosion
            FindObjectOfType<GameManager>().EndGame();            
        }
    }
