    using System.Reactive.Subjects;
    public class MyAPI
    {
        private readonly Subject<IResult> callback1 = new Subject<IResult>();
        private readonly Subject<IResult> callback2 = new Subject<IResult>();
        public void StartService()
        {
            //step 1
            int i = 0;
            ConcreteResult result1 = new ConcreteResult();
            result1.i = i;
            callback1.OnNext(result1);
            //step 2
            i += 1;
            ConcreteResult result2 = new ConcreteResult();
            result2.i = i;
            callback2.OnNext(result2);
        }
        public IObservable<IResult> Callback1 => this.callback1;
        public IObservable<IResult> Callback2 => this.callback2;
    }
    public static class Program
    {
        public static void Main()
        {
            var api = new MyAPI();
            // Subscribing returns a disposable subscription, and disposing it unsubscribes.
            // That means you can use lambda syntax and still unsubscribe later
            IDisposable subscription =
                api.Callback1.Subscribe(result => Console.WriteLine(result.i)); 
            api.StartService(); // Writes result.
            
            // Once disposed, event is no longer called
            subscription.Dispose();
            api.StartService(); // Doesn't write result.
            // Since IDisposable is a special thing that can be scoped to using blocks in C#, you can do the following:
            using (api.Callback1.Subscribe(result => Console.WriteLine(result.i)))
            {
                api.StartService(); // Writes result
            }
            api.StartService(); // Doesn't write result
        }
    }
