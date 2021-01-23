    namespace Lesson02
    {
        class Rectangle
        {
            // Method, here we execute
            static void Main(string[] args)
            { 
                // Executions are within the method
                Rectangle rect = new Rectangle(10.0, 20.0);
                double area = rect.GetArea();
                Console.WriteLine("Area of Rectagle: {0}", area);
            }
    
            // Declarations
            private double length;
            private double width;
    
            public Rectangle(double l, double w)
            {
                length = l;
                width = w;
            }
    
            public double GetArea()
            {
                return length * width;
            }
        }
    }
