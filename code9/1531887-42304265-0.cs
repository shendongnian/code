    private static async Task MainAsync()
        {
            var httpClient = new HttpClient();
            Func<Task> action = async () =>
            {
                var response = await httpClient.GetAsync("http://web4host.net/200MB.zip").ConfigureAwait(false);
                // this never gets executed
                var array = await response.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes("C:/mytmp/bytefile.xxx", array);
                return;
            };
            await MeasureExecutionTimeAsync(action);
        }
        private static async Task MeasureExecutionTimeAsync(Func<Task> measuredAction)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await measuredAction.Invoke();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
        }
