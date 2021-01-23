    class RectCollisionHandler : AbstractCollisionHandler
    {
        public override void Collides(Circle other)
        {
            Console.WriteLine("Collision rect-circle");
        }
        public override void Collides(Tri other)
        {
            Console.WriteLine("Collision rect-tri");
        }
        public override void Collides(Rect other)
        {
            Console.WriteLine("Collision rect-rect");
        }
    }
