        private static async Task RunParallel()
        {
            var tasks = new List<Task>();
            for (var i = 0; i < 300; i++)
            {
                tasks.Add(CallSomeWebsite(i));
            }
            Console.WriteLine("All loaded");
            await Task.WhenAll(tasks);
        }
        private static async Task CallSomeWebsite(int i)
        {
            var watch = Stopwatch.StartNew();
            using (var result = await _httpClient.GetAsync("https://www.google.com").ConfigureAwait(false))
            {
                // more work here, like checking success etc.
                Console.WriteLine($"{i}: {watch.ElapsedMilliseconds}");
            }
        }
