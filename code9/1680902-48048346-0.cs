    protected override IDeviceGestureService OnCreateDeviceGestureService()
    {
        var svc = base.OnCreateDeviceGestureService();
        svc.UseTitleBarBackButton = false;
        return svc;
    }
