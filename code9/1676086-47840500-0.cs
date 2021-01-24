    public class Rectangle
    {
    
        public int length { get; set; }
        public int breadth { get; set; }
    
        public int area()
        {
            return length * breadth;
        }
    
    }
    
    public class Square : Rectangle
    {
    
    }
