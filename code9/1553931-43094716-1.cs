    void OnCollisionEnter2D (Collision2D coll) {
        // If the tag of the thing we collide with is "Player"...
        if (coll.gameObject.tag == "Player")
            Debug.Log("Player hit!");
        // Ignore the collision with the player.
        Physics2D.IgnoreCollision(player.collider, collider);
    }
