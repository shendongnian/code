    class Program
    {
        static void Main(string[] args)
        {
            var job = new Job { Id = 1, Name = "Todo", Description = "Nothing" };
            Console.WriteLine($"{job.Name} job for admin");
            Console.ReadLine();
        }
    }
