    // assuming your main class is MainFunction
    public class MainFunction()
    {
        public Rover rov { get; private set; }
        public static void Main(string[] args)
        {
            // Establish the reusable rover
            rov = new Rover();
            // ...
        }
    }
