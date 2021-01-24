    public class Message
    {
        public string Text { get; set; }
        public Exception Error { get; set; }
    }
    public IObservable<Message> StartStreaming()
    {
        return Observable.Create(
            async (IObserver<Message> observer) =>
            {
                for (int i = 0; i < 2; i++)
                {
                    observer.OnNext(new Message { Text = $"sending...{i}" });
                    await Task.Delay(1000);
                }
                observer.OnNext(new Message { Error = new Exception("Invalid Request") });
            });
