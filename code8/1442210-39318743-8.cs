    static void Collides(IShape a, IShape b)
    {
        if (a.CollisionPrecedence >= b.CollisionPrecedence)
            b.Collide(a.CollisionHandler);
        else
            a.Collide(b.CollisionHandler);
    }
