    public async Task MyMehod()
    {
                Task<IEnumerable<int>> infoGetTask = GetAllInformation();
    
                Stopwatch stopwatch = Stopwatch.StartNew();
    
                while (!infoGetTask.IsCompleted)
                {
                    Console.Write($"Elapsed time... {Math.Round(stopwatch.Elapsed.TotalSeconds, 0)}");
                    await Task.Delay(1000);
                }
    
                foreach (int e in infoGetTask.Result)
                {
                    Console.WriteLine(e);
                }
            }
    
            public async Task<IEnumerable<int>> GetAllInformation()
            {
                await Task.Delay(3000);
    
                return new int[3] { 1, 2, 3 };
            }
