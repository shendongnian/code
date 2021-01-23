    class CircleCollisionHandler : AbstractCollisionHandler
    {
        public override void Collides(Circle other)
        {
            Console.WriteLine("Collision circle-circle");
        }
    }
    class Circle : IShape
    {
        public int CollisionPrecedence { get { return 0; } }
        public AbstractCollisionHandler CollisionHandler { get { return new CircleCollisionHandler(); } }
        public void Collide(AbstractCollisionHandler handler) { handler.Collides(this); }
    }
    class TriCollisionHandler : AbstractCollisionHandler
    {
        public override void Collides(Circle other)
        {
            Console.WriteLine("Collision tri-circle");
        }
        public override void Collides(Tri other)
        {
            Console.WriteLine("Collision tri-tri");
        }
    }
    class Tri : IShape
    {
        public int CollisionPrecedence { get { return 1; } }
        public AbstractCollisionHandler CollisionHandler { get { return new TriCollisionHandler(); } }
        public void Collide(AbstractCollisionHandler handler) { handler.Collides(this); }
    }
