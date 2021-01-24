    class Circle
    {
        public double Radius
        {
            get;
            set;
        }
        
        public double Area
        {
            get
            {
                return 3.142 * radius * radius;
            }
        }
    
        public Circle(double radius)
        {
            Radius = radius;
        }
    
        public void displayArea()
        {
            Console.WriteLine("The area is " + Area.ToString());
            Console.ReadLine();
        }
    }
