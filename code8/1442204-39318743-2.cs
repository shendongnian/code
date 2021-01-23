    static bool Collides(IShape a, IShape b)
    {
        if (a.CollisionPrecedence >= b.CollisionPrecedence)
            return b.Collide(a.CollisionHandler);
        else
            return a.Collide(b.CollisionHandler);
    }
