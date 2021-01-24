    var observer = new EventObserver();
    using (EventMonitor.Instance.Observe(observer, ...))
    {
        await plan.ExecuteAsync(...);
    }
    var events = await observer.Task; // Doh!
