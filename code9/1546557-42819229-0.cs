    private async Task SetMessages()
    {
        MessageList = new ObservableCollection<IMessage>(await channel.GetMessagesAsync(20).Flatten());
        Bindings.Update();
    }
