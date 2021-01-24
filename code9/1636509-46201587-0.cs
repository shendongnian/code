    public class ChainableTask
    {
        private readonly Task _task;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
    
        public ChainableTask(Func<CancellationToken, Task> asyncAction,
                            ChainableTask previous = null)
        {
            _task = Execute(asyncAction, previous);
        }
    
        private async Task CancelAsync()
        {
            try
            {
                _cts.Cancel();
                await _task;
            }
            catch (OperationCanceledException)
            { }
        }
    
        private async Task Execute(Func<CancellationToken, Task> asyncAction, ChainableTask previous)
        {
            if (previous != null)
                await previous.CancelAsync();
    
            if (_cts.IsCancellationRequested)
                return;
    
            await asyncAction(_cts.Token);
        }
    }
