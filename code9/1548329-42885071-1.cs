    private ConcurrentQueue<Message> Queue = new ConcurrentQueue<Message>();
    private int QueueSize = 0;
    private int LastSend = (int)(DateTime.Now.Ticks >> 23);
    private int LastMessage = (int)(DateTime.Now.Ticks >> 23);
    
    public void GotNewMessage(Message Message)
    {
        Queue.Enqueue(Message);
    
        Interlocked.Increment(ref QueueSize);
        Interlocked.Exchange(ref LastMessage, (int)(DateTime.Now.Ticks >> 23));
    
        if (Interlocked.CompareExchange(ref QueueSize, 0, 100) == 100 || 
            LastMessage - LastSend >= 60)
        {
            Message Dummy;
            while (!Queue.IsEmpty)
                if (Queue.TryDequeue(out Dummy))
                    SendMessage(Dummy);
    
            Interlocked.Exchange(ref LastSend, (int)(DateTime.Now.Ticks >> 23));
        }
    }
    
    public void SendMessage(Message Message)
    {
        // ...
    }
