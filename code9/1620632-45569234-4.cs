    public async Task Publish(IMessage message)
    {
        await bus.Publish((object) message);
        ...
    }
