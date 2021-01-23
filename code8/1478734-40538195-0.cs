    public class AsyncDelayer : IAsyncDelayer
    {
        public Task Delay(TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan);
        }
    }
