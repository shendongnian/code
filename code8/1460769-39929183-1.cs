    public class Yamaha : Motorcycle
    {       
        public string GetColor()
        {
            // ....
            return "Red";
        }
        // When a method in class is marked as abstract,
        // all the class that inherit should provide an implementation
        // of this method. Otherwise you would get a compilation error.
        public double GetTopSpeed()
        {
            return 200;
        }
        // When a method is marked as virtual, we have two options for the derived classes.
        // 1. Use the implementation provided int the base class.
        // 2. Override this implementation, define a method like below and provide
        // your implementation. 
        public override int Drive(int miles, int speed) 
        { 
            /* Method statements here */ return 2; 
        }
    }
