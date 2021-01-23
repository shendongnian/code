    public class Yamaha : Motorcycle
    {       
        public string GetColor()
        {
            // ....
        }
        // When a method in class is marked as abstract,
        // all the class that inherit should provide an implementation
        // of this method. Otherwise you would get a compilation error.
        public double GetTopSpeed()
        {
            return 200;
        }
    }
