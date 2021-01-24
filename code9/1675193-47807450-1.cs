        static void Main(string[] args)
        {
            var p1x = RequestUserInput_Double("Enter 1st point x value:");
            var p1y = RequestUserInput_Double("Enter 1st point y value:");
            var p2x = RequestUserInput_Double("Enter 2nd point x value:");
            var p2y = RequestUserInput_Double("Enter 2nd point y value:");
            var p1 = new Point2d(p1x, p1y, "SomeName");
            var p2 = new Point2d(p2x, p2y, "SomeOtherName");
        }
        public static double RequestUserInput_Double(string requestString)
        {
            Console.WriteLine(requestString);
            var userInput = Console.ReadLine();
            double value;
            // Try to parse the user input into a double value
            while(!Double.TryParse(userInput, out value))
            {
                Console.WriteLine("Invalid format. Please enter a valid double value:");
                userInput = Console.ReadLine();
            }
            return value;
        }
