    class Program
    {
        static void Main(string[] args)
        {
            List<Driver> drivers = new List<Driver>() {
                new Driver { Points = 20 , Class = "Rookie"},
                new Driver { Points = 50, Class = "Rookie"},
                new Driver { Points = 10 , Class = "Rookie"},
                new Driver { Points = 80 , Class = "Rookie"},
                new Driver { Points = 60 , Class = "Rookie"},
                new Driver { Points = 11 , Class = "Rookie"},
                new Driver { Points = 7 , Class = "Rookie"},
                new Driver { Points = 99 , Class = "SomeOther"},
            };
            var topThree = drivers.Where(x => x.Class == "Rookie")
                .OrderByDescending(x => x.Points)
                .Take(3);
            // 99 Will not be present
            foreach (var driver in topThree)
            {
                Console.WriteLine(driver.Points);
            }
            Console.Read();
        }
    }
    internal class Driver
    {
        public int Points { get; internal set; }
        public string Class { get; set; }
    }
