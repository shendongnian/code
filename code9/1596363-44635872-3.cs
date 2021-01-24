    public Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
    {
        ActorEventSource.Current.Message($"Actor recieved reminder {reminderName}.");
        
        ...
    }
