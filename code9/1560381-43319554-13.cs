    var mc = new MyClass();
    using (var wrapper = new TDeviceWrapper())
    {
        wrapper.Init();
        wrapper.SetStatus(mc.StatusEvent);
        wrapper.SetResult(mc.ResultEvent);
        wrapper.Connect();
    }
