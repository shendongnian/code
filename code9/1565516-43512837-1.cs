    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var poco = new Poco();
            configuration.Bind(poco);
            Console.WriteLine(poco);
            Console.ReadKey();
        }
    }
    class Poco
    {
        public bool Enabled { get; set; }
        public Sort Sort { get; set; }
        public override string ToString()
        {
            return $"Enabled={Enabled}, SortOrder={Sort.Order}";
        }
    }
    class Sort
    {
        public int Order { get; set; }
    }
