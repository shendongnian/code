    public class DataInfo { }
    private Thread mReceivingThread;
    private Thread mSendingThread;
    private BlockingCollection<DataInfo> queue;
    private CancellationTokenSource receivingCts = new CancellationTokenSource();
    private void ReceivingThread()
    {
        try
        {
            while (!receivingCts.IsCancellationRequested)
            {
                // This will block until an item is added to the queue or the cancellation token is cancelled
                DataInfo item = queue.Take(receivingCts.Token);
                ProcessReceivingItem(item);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }
    internal void EnqueueRecevingData(DataInfo info)
    {
        // When a new item is produced, just add it to the queue
        queue.Add(info);
    }
    // To cancel the receiving thread, cancel the token
    private void CancelReceivingThread()
    {
        receivingCts.Cancel();
    }
