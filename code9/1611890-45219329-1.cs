      static void Main(string[] args)
        {
            Console.WriteLine("How many inches would you like to convert?");
            int inches = Convert.ToInt32(Console.ReadLine());
            
            double numOfFeet = ConvertToFeet(inches);
            double numOfYards = ConvertToYards(inches);
            double numOfMiles = ConvertToMiles(inches);
            
            Console.WriteLine(inches + " inches is equivalent to " + string.Format("{0:N2}", numOfFeet) + " feet, or " + string.Format("{0:N2}", numOfYards) + " yards, or " + string.Format("{0:N2}", numOfMiles) + " miles.");
            Console.ReadLine();
        }
        private static double ConvertToMiles(int inches)
        {
            int miles = 63360;
            return inches / miles;
        }
        private static double ConvertToYards(int inches)
        {
            int yards = 36;
            return inches / yards;
        }
        private static double ConvertToFeet(double inches)
        {
            int feet = 12;
            return inches / feet;
        }
    }
