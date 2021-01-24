    void OnCollisionEnter(Collision collision) 
    {
        ICollidableObject collidedWith = collision.gameObject.GetComponent<ICollidableObject>();
        if ( collidedWith != null )
            collidedWith.CollidedWith(this);
    }
