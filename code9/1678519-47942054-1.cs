    private readonly object _activeTasksLock = new object();
    private int _activeTasks;
    private CancellationTokenSource _cts = new CancellationTokenSource();
    private async Task ProcessData(CancellationToken ct) {
        lock (_activeTasksLock) {
            // increment number of active tasks
            _activeTasks++;
        }
        try {
            // do stuff
            await Task.Delay(1000, ct);
            // check cancellation token and exit if necessary
        }
        finally {
            lock (_activeTasksLock) {
                // decrement and notify
                _activeTasks--;
                Monitor.Pulse(_activeTasksLock);
            }
        }
    }
    public override void OnStop() {
        // dispose\stop your timer here
        // then cancel
        _cts.Cancel();
        // then wait until all is done
        lock (_activeTasksLock) {
            while (_activeTasks > 0)
                Monitor.Wait(_activeTasksLock);
        }
    }
