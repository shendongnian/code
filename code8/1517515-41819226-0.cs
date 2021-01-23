    class Program
    {
        static void Main(string[] args)
        {
            Time startTime = new Time();
            startTime.Day = 1;
            startTime.Month = 1;
            startTime.Year = 2000;
            DateTime gameDate = new DateTime(startTime.Year, startTime.Month, startTime.Day);
            Console.WriteLine(gameDate);
            Console.ReadLine();
        }
    }
    class Time
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
