    static AutoResetEvent MeasureMessageEvent = new AutoResetEvent(true);
    private static void HandleMeasurementMessage(IMessage<MessageEnvelope> msg)
    {
        /* Do a bunch of stuff to msg */
        // Wait for exclusive access
        MeasureMessageEvent.WaitOne();
        EventHubDataBatch.Push(eventHubDatum);
        if(EventHubDataBatch.Count == 100)
        {
           /* Send them off*/
           EventHubDatabatch.Clear();
        }
        
        // Release exclusive access
        MeasureMessageEvent.Set();
    }
