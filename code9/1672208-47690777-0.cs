    private async Task<Tuple<string, int>> Poll(string type, int delay, CancellationToken ct) {
        await Task.Delay(Math.Max(1000, delay), ct);
        Console.WriteLine($"poll {type} status");
        // return input arguments back
        return Tuple.Create(type, delay);
    }
    private async Task PollAll(CancellationToken ct) {
        var tasks = new []
        {
            Poll("A", 3000, ct),
            Poll("B", 2000, ct),
            Poll("C", 1000, ct)
        };
        while (!ct.IsCancellationRequested) {
            var completed = await Task.WhenAny(tasks);
            var index = Array.IndexOf(tasks, completed);
            // await to throw exceptions if any
            await completed;                                
            // replace with new task with the same arguments
            tasks[index] = Poll(completed.Result.Item1, completed.Result.Item2, ct);
        }
    }
