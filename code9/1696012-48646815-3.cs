    Task MethodX() {
        async Task Awaited(Task a, Task b) {
            await a;
            await b;
        }
        Task x = ...;
        Task y = ...;
        if (x.Status == TaskStatus.RanToCompletion &
            y.Status == TaskStatus.RanToCompletion)
            return Task.CompletedTask; // sync
        return Awaited(x, y); // async
    }
