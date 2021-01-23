        static void Main(string[] args)
        {
            var parser = new TimeParser();
            Console.WriteLine(parser.Parse("60:34").TotalSeconds); //218040 seconds, hh:mm
            Console.WriteLine(parser.Parse("55:10").TotalSeconds); //3310 seconds, mm:ss
            Console.WriteLine(parser.Parse("3:33:34").TotalSeconds); //12814 seconds, hh:mm:ss
            Console.WriteLine(parser.Parse("12:34", TimeParser.Format.HoursMinutes).TotalSeconds); //45240 seconds
            Console.WriteLine(parser.Parse("55:10", TimeParser.Format.MinutesSeconds).TotalSeconds); //3310 seconds
            Console.WriteLine(parser.Parse("3:33:34", TimeParser.Format.HoursMinutesSeconds).TotalSeconds); //12814 seconds
            Console.ReadKey();
        }
