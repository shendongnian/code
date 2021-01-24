    public async Task Publish(object message)
    {
        await bus.Publish((object) message);
        ...
    }
