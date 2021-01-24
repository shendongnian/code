    public class TestLazyObservable
    {
        public TestLazyObservable(IObservable<int> lazyPart)
        {
            this.LazyPart = lazyPart;
        }
        public IObservable<int> LazyPart { get; }
    }
    public static async void TestObservable()
    {
        Trace.TraceInformation("Creating observable");
        // From async to demonstrate the Task compatibility of observables
        var lazyTask = Observable.FromAsync(() => Task.Run(() =>
        {
            Trace.TraceInformation("Observable run");
            return 0;
        }));
        var taskWrapper = new TestLazyObservable(lazyTask);
        Trace.TraceInformation("Calling await on observable");
        await taskWrapper.LazyPart;
    }
