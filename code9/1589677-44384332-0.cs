    class Foo
    {
        public string IPAddress { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string TimeZone { get; set; }
        public string Request { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Log.txt");
           
            foreach(string line in lines)
            {
                string[] split = line.Split(' ', '<', '>', '[', ']', '-', '"', ';', '(', ')', '+', ':');
                split = split.Where(r => !string.IsNullOrWhiteSpace(r)).ToArray();
                Foo foo = new Foo();
                foo.IPAddress = split[0];
                foo.Date = split[1];
                foo.Time = string.Format("{0}:{1}:{2}", split[2], split[3], split[4]);
                foo.TimeZone = split[5];
                foo.Request = split[6];
                Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", foo.IPAddress, foo.Date, foo.Time, foo.TimeZone, foo.Request));
            }
            Console.ReadLine();
        }
    }
