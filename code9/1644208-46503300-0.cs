    void Main()
    {
     // You will not be able to change value for const variable.
     Console.WriteLine(Myclass.G);
    
      // You will be able to change value for static variable, 
     // and this change will impact all users of the application.
     //  For every user, this field will store value of 10 now. 
     // That will not be required or desired code behavior.
     Myclass1.G = 10;
     Console.WriteLine(Myclass1.G);
    }
    // Normal class with const field 
    class Myclass
    {
        public const double G=9.8;
    }
     
     //static class with static constructor
     static class Myclass1
        {
            public static double G{get;set;}
            static Myclass1()
            {
                G=9.8;
            }
        }
