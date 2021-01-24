        void OnCollisionEnter2D(Collision2D col)
    {
       // Debug.Log("Player has collided with " + col.collider.name);
        isGrounded = true;
        marioFalling = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * marioSpeed, 0); // Väldigt viktig, återställer hastigheten (i y) till noll, istället för att lägga till tidigare hastighet på nästa hopp.
        if (col.otherCollider is BoxCollider2D)
        {
            Debug.Log("Marios body is being tickled");
        }
        if (col.otherCollider is CapsuleCollider2D)
        {
            Debug.Log("Marios feet is being touched");
        }
    }
