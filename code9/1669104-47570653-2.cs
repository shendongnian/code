    public void Handle(object message) // accept any type of message
    {
        Type handlerType = typeof(IRequest<>).MakeGenericType(message.GetType());
        dynamic handler = this.container.GetInstance(handlerType);
        // Use 'dynamic' as simplified form of Reflection.
        handler.Handle((dynamic)message);
    }
