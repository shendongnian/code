    static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var rates = new List<string>();
            var p44Task = Task.Factory.StartNew(() => GetP44Rates(token), token);
            var mgRates = GetMGRates(token).GetAwaiter().GetResult();
            rates.AddRange(mgRates);
            if (p44Task.IsCompleted && p44Task.Result.IsCompleted)
            {
                rates.AddRange(p44Task.Result.Result);
            }
            else
            {
                // Cancel the p44 task
                tokenSource.Cancel();
            }
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }
            Console.ReadLine();
        }
        private static async Task<List<string>> GetMGRates(CancellationToken cancellationToken)
        {
            var rates = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                rates.Add($"MG: {i}");
                Console.WriteLine($"MG inside {i}");
                await Task.Delay(1000);
            }
            return rates;
        }
        private static async Task<List<string>> GetP44Rates(CancellationToken ct)
        {
            var rates = new List<string>();
            for (var i = 0; i < 50; i++)
            {
                rates.Add($"P44: {i}");
                Console.WriteLine($"P44: {i}");
                await Task.Delay(1000);
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("bye from p44.");
                    Console.WriteLine("\nPress Enter to quit.");
                    
                    ct.ThrowIfCancellationRequested();
                }
            }
            return rates;
        }
