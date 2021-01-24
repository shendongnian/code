    private static readonly List<EventHubDatum> EventHubDataBatch = new List<EventHubDatum>();        
    private static void HandleMeasurementMessage(IMessage<MessageEnvelope> msg)
    {
        /* Do a bunch of stuff to msg */
        EventHubDatum[] toSend = null;
        lock (EventHubDataBatch) {
            EventHubDataBatch.Add(eventHubDatum);
            if (EventHubDataBatch.Count == 100) {
                // copy to local
                toSend = EventHubDataBatch.ToArray();
                EventHubDataBatch.Clear();
            }
        }
        if (toSend != null) {
            /* Send them off*/
        }
    }
