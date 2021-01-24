    class Program
    {
        //since c# 7
        static async Task Main()
        {
            //use this or other options I provided
            await WrapperAsync();
            WriteLine("Ended...");
        }
        //earlier versions of c#
        static void Main() 
        {
            WrapperAsync().Wait();
            WriteLine("Ended...");
        }
    
    
        static async Task WrapperAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                int start = i == 0 ? 3 : 1000_000 * i;
                int stop = 1000_000 * (i + 1) - 1;
               
                //you can also change it here to do exactly what you want
                var task = GetPrimeCountAsync(start, stop)
                    .ContinueWith(t => WriteLine($"The number of primes between {start} and {stop} is {t.Result}"));
            }
        }
    
        //  Note that 2 < start <= stop 
        static async Task<int> GetPrimeCountAsync(int start, int stop)
        {
            var count = ParallelEnumerable.Range(start, stop - start + 1)
                        .Where(i => i % 2 > 0)
                        .Count(j => Enumerable.Range(3, (int)Math.Sqrt(j) - 1).Where(k => k % 2 > 0).All(l => j % l > 0));
    
            return count;
        }
    }
