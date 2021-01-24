    class MultiAsyncTest {
        Task SomeAsync1() { return Task.Delay(1000); }
        Task SomeAsync2() { return Task.Delay(2000);}
        Task EntryPointAsync() {
            var tasks = new List<Task>();
            tasks.Add(SomeAsync1());
            tasks.Add(SomeAsync2());
            return Task.WhenAll(tasks);
        }
    }
