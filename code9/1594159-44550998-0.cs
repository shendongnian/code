    public class shape : Shape
    {
        ...
        ...
        public int GetArea()
        {
            return 0;//Return an int value
        }
    }
    class Rectangle : Shape
    {
        ...
        ...
        public int GetArea()
        {
            int area = height * width;
            return area;
        }
    }
