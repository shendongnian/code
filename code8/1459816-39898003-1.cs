    public CircleCollider2D myCircleCollider;
    
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.IsTouching(myCircleCollider))
        {
    
        }
    }
