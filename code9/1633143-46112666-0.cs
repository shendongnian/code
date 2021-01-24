    EventHandler<Exception> OnException=delegate{};
    public void UpdateSubscribe(Action<object, UpdateArgs> action, EventHandler<Exception> exceptionHandler)
    {
        lock (UpdateLock)
        {
            OnException+=exceptionHandler;
            UpdateSubscribersList.Add(action);
        }
    }
