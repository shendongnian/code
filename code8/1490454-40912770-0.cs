    public static async void TestParallelTaskCancelation()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Task[] tasks =
            {
            Task.Factory.StartNew(DummyTask, cancellationTokenSource, cancellationTokenSource.Token),
            Task.Factory.StartNew(DummyTask, cancellationTokenSource, cancellationTokenSource.Token),
            Task.Factory.StartNew(DummyTask, cancellationTokenSource, cancellationTokenSource.Token),
            Task.Factory.StartNew(DummyTask, cancellationTokenSource, cancellationTokenSource.Token),
            Task.Factory.StartNew(FailureTask, cancellationTokenSource, cancellationTokenSource.Token)
            };
            try
            {
               await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
