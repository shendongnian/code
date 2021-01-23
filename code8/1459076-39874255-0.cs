    class Program
    {
        static void Main(string[] args)
        {
            var job = new Job { Id = 1, Name = "Todo", Description = "Nothing" };
            Console.WriteLine($"{job.Name} job for admin");
            Console.ReadLine();
        }
    }
    
    class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
