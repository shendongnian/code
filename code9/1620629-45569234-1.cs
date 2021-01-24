    using (var uow = new Wrapper(ctx, bus))
    {
        var itemMsg = new ItemChangedMessage() { Value = item.Value };
    
        await uow.Publish(itemMsg);
    }
...
    public async Task Publish(object message)
    {
        await bus.Publish(message);
        ...
    }
