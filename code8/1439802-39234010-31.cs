        private static async Task<string> GetSomethingTheLongWayAsync(int key)
        {
            await Task.Delay(15000);
            Console.WriteLine("Long way for: " + key);
            return key.ToString();
        }
        static void Main(string[] args)
        {
            Test().Wait();
        }
        private static async Task Test()
        {
            int key;
            string val;
            key = 1;
            var cache = new Cached<int, string>(GetSomethingTheLongWayAsync, 1);
            Console.WriteLine("getting " + key);
            val = await cache.GetSomethingAsync(key);
            Console.WriteLine("getting " + key + " resulted in " + val);
            Console.WriteLine("getting " + key);
            val = await cache.GetSomethingAsync(key);
            Console.WriteLine("getting " + key + " resulted in " + val);
            await Task.Delay(65000);
            Console.WriteLine("getting " + key);
            val = await cache.GetSomethingAsync(key);
            Console.WriteLine("getting " + key + " resulted in " + val);
            Console.ReadKey();
        }
