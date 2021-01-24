           var testStrings = new List<string>();
            for (var i = 0; i < 5000; i++)
            {
                testStrings.Add($"string-{i}");
            }
    
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
    
            using (var semaphore = new SemaphoreSlim(10))
            {
                var tasks = testStrings.Select(async testString =>
                {
                        await semaphore.WaitAsync();
                        try
                        {
                           if (!cancellationToken.IsCancellationRequested)
                           {
                               Console.WriteLine($"{testString}-Start");
                               await Task.Delay(2000);
                               throw new Exception("test");
                           }
                        }
                        catch (Exception ex)
                        {
                            if (!cancellationTokenSource.IsCancellationRequested)
                                cancellationTokenSource.Cancel();
                            throw;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                });
    
                await Task.WhenAll(tasks);
            }
