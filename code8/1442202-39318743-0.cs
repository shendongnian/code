    interface IShape
    {
        int CollisionPrecedence { get; }
        AbstractCollisionHandler CollisionHandler { get; }
        void Collide(AbstractCollisionHandler handler);
    }
    class AbstractCollisionHandler
    {
        public virtual void Collides(Circle other) { throw new NotImplementedException(); }
        public virtual void Collides(Rect other) { throw new NotImplementedException(); }
    }
