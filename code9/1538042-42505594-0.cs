    class RectangleExample
    {
       double i  ;
       double j ;
      // class will be created calling `contructor`. Constructor will be call GetValues and set i , j values...
      RectangleExample()
      {
         GetValues();
      }
        public void GetValues()
        {
             i = 2.5;
             j = 3.5;
        }
    
        public  double GetArea()
        {
            return i * j;
        }
    
        public  void Display()
        {
    
            Console.WriteLine("Length: {0}", i);
            Console.WriteLine("width: {0}", j);
            Console.WriteLine("Area: {0}", GetArea());
    
        }
    }
