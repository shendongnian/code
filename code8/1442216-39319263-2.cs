    public abstract class Shape
    {
        private CollisionDetector detector = new CollisionDetector();
        public bool IsColliding(Shape that)
        {
            return detector.IsColliding((dynamic) this, (dynamic) that);
        }
    }
    public class CollisionDetector
    {
        public bool IsColliding(Circle circle1, Circle circle2)
        {
            Console.WriteLine("circle x circle");
            return true;
        }
        public bool IsColliding(Circle circle, Rectangle rectangle)
        {
            Console.WriteLine("circle x rectangle");
            return true;
        }
        public bool IsColliding(Rectangle rectangle, Circle circle)
        {
            // Just reuse the previous method, it is the same logic:
            return IsColliding(circle, rectangle);
        }
        public bool IsColliding(Rectangle rectangle1, Rectangle rectangle2)
        {
            Console.WriteLine("rectangle x rectangle");
            return true;
        }
    }
    public class Circle : Shape { }
    public class Rectangle : Shape { }
