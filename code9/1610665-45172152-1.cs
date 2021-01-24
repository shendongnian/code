    class Program
    {
        static void Main(string[] args)
        {
            var ageIncrementor = new AgeIncrementor();
            Console.WriteLine("Age is {0}", ageIncrementor.Age);
            var tasks = Enumerable.Range(0, 5)
                                  .Select(i => ageIncrementor.IncrementAge(i))
                                  .ToArray();
            Task.WaitAll(tasks);
            ageIncrementor.Complete();
            Console.WriteLine("Completed");
            Console.WriteLine("Final Age is {0}", ageIncrementor.Age);
            Console.ReadKey();
        }
    }
    // watch the numbers passed in when the different tasks were started
    public class AgeIncrementor
    {
        //doesn't need to be static since you are only using one instance
        private readonly object syncLock = new object();
        private Random Random = new Random();
    
        public int Age { get; set; }
        public Task IncrementAge(int index)
        {
            return Task.Run(() =>
            {
                // act like work before lock
                Thread.Sleep(this.Random.Next(10) * 10);
                lock (syncLock)
                {
                    // act like work before change                      
                    Thread.Sleep(this.Random.Next(10) * 10);
                    Age += 10;                    
                    // act like work after change before release
                    Thread.Sleep(this.Random.Next(10) * 10);
                    Console.WriteLine("Increased to {0} ({1})", Age, index);
                }
            });
        }
        public void Complete()
        {
            Console.WriteLine("Printing from Complete() method.");
        }
    }
