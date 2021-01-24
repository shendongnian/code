    var observer = new EventObserver();
    using (EventMonitor.Instance.Observe(...))
    {
        await plan.ExecuteAsync(...);
    }
    var events = await observer.Task; // Doh!
