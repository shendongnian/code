    private async Task SetMessages()
    {
        IEnumerable newData = await channel.GetMessagesAsync(20).Flatten();
        // Assuming MessageList is not null here you will sync newData with MessageList
    }
