    class Program
    {
        static void Main(string[] args)
        {
            var ageIncrementor = new AgeIncrementor();
            Console.WriteLine("Age is {0}", ageIncrementor.Age);
            var tasks = Enumerable.Range(0, 5)
                                  .Select(i => ageIncrementor.IncrementAge())
                                  .ToArray();
            Task.WaitAll(tasks);
            ageIncrementor.Complete();
            Console.WriteLine("Completed");
            Console.WriteLine("Final Age is {0}", ageIncrementor.Age);
            Console.ReadKey();
        }
    }
    public class AgeIncrementor
    {
        private static readonly object syncLock = new object();
        public AgeIncrementor()
        {
            Age = 0;
        }
        public int Age { get; set; }
        public Task IncrementAge()
        {
            return Task.Run(() =>
            {
                try
                {
                    lock (syncLock)
                    {
                        Age += 10;
                        Console.WriteLine("Increased to {0}", Age);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void Complete()
        {
            Console.WriteLine("Printing from Complete() method.");
        }
    }
