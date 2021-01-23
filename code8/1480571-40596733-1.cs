    public class IgnoreTaskCancellation
    {
        [Fact]
        public void ShouldThrowAnAggregateException()
        {
            CancellationTokenSource cts = new CancellationTokenSource(10);
            Task taskA = Task.Delay(20, cts.Token);
            Task taskB = Task.Delay(20, cts.Token);
            Task taskC = Task.Delay(20, cts.Token);
            Assert.Throws<AggregateException>(() => Task.WhenAll(taskA, taskB, taskC).Wait());
        }
        [Fact]
        public void ShouldNotThrowAnException()
        {
            CancellationTokenSource cts = new CancellationTokenSource(10);
            Task taskA = Task.Delay(20, cts.Token);
            Task taskB = Task.Delay(20, cts.Token);
            Task taskC = Task.Delay(20, cts.Token);
            Task.WhenAll(taskA, taskB, taskC).ContinueWith(t => { }, TaskContinuationOptions.OnlyOnCanceled).Wait();
        }
        [Fact]
        public void ShouldNotThrowAnExceptionUsingIgnore()
        {
            CancellationTokenSource cts = new CancellationTokenSource(10);
            Task taskA = Task.Delay(20, cts.Token);
            Task taskB = Task.Delay(20, cts.Token);
            Task taskC = Task.Delay(20, cts.Token);
            Task.WhenAll(taskA, taskB, taskC).IgnoreCancellation().Wait();
        }
    }
