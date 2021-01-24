    //Variable to hold the contacts
    ContactPoint2D[] contacts = new ContactPoint2D[2];
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Get all contact points and save to the contacts array variable
        collision.GetContacts(contacts);
    
        Vector3 normal = contacts[0].normal;
        Vector2 point = contacts[0].point;
    }
