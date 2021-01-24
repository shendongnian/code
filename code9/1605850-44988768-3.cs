    public class Rectangle : Shape
    {
        private int num = 10;
        ...
        public override string ToString()
        {
            return $"Rectangle num = {num}";
        }
    }
...
    Shape shape = new Rectangle();
    Console.WriteLine(shape); // Uses ToString() of rectangle.
