    public interface ICalculation
    {
        void Run();
    }
    public class SpeedCalculation
        : ICalculation
    {
        public void Run()
        {
            Console.WriteLine("You have chose to calculate speed. S = D/T");
            Console.WriteLine("To work this out you need to firstly enter your distance in metres");
            string userDistance = Console.ReadLine();
            int Distance = int.Parse(userDistance);
            Console.WriteLine("Now enter your time in seconds.");
            string userTime = Console.ReadLine();
            int Time = int.Parse(userTime);
            Console.WriteLine("Your speed is " + Distance / Time + " m/s");
            Console.WriteLine("In MPH this is " + Distance / Time * 2.23 + "MPH");
        }
    }
    ...more ICalculation types...
    class Program
    {
        static void Main(string[] args)
        {
            var caseDictionary = new Dictionary<int, ICalculation>
            {
                {1, new SpeedCalculation()},
                {2, new DistanceCalculation()},
                {3, new TimeCalculation()}
            };
            Console.WriteLine("This is a system to calculate speed, distance or time.");
            Console.WriteLine("1 = Speed - 2 = Distance - 3 = time");
            Console.WriteLine("Please enter which calculation you would like to perform. 1, 2 or 3");
            string userCalculation = Console.ReadLine();
            int Calculation = int.Parse(userCalculation);
            if(!caseDictionary.ContainsKey(Calculation))
            {
                Console.WriteLine("Please enter a number between 1 and 3 (inclusive).");
            }
            else
            {
                caseDictionary[Calculation].Run();
            }
        }
    }
