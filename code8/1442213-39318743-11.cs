    class Rect : IShape
    {
        public int CollisionPrecedence { get { return 2; } }
        public AbstractCollisionHandler CollisionHandler { get { return new RectCollisionHandler(); } }
        public void Collide(AbstractCollisionHandler handler) { handler.Collides(this); }
    }
