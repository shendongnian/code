    public class TestLazyTask
    {
        private Task<int> lazyPart;
        public TestLazyTask(Task<int> lazyPart)
        {
            this.lazyPart = lazyPart;
        }
        public Task<int> LazyPart
        {
            get
            {
                // You have to start it manually at some point, this is the naive way to do it
                this.lazyPart.Start();
                return this.lazyPart;
            }
        }
    }
    
    public static async void Test()
    {
        Trace.TraceInformation("Creating task");
        var lazyTask = new Task<int>(() =>
        {
            Trace.TraceInformation("Task run");
            return 0;
        });
        var taskWrapper = new TestLazyTask(lazyTask);
        Trace.TraceInformation("Calling await on task");
        await taskWrapper.LazyPart;
    } 
