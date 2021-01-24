    public Task Handle(CarMoved message, IMessageHandlerContext context)
    {
        Application.Current.Dispatcher.BeginInvoke(new Action(() => { Cars.Add(new Car()); }));
        return Task.CompletedTask;
    }
