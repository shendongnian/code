    void OnCollisionEnter(Collision col)
    {
        if (col is BoxCollider2D)
        {
            //When it hits the box
        }
        else if(col is PolygonCollider2D)
        {
            //When it hits the polygon
        }
    }
