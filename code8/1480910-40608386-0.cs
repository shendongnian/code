    ...
    mgr.OnStart = this.Mgr_Start;
    ...
    private void Mgr_Start(object sender)
    {
        var sga = sender.GetAllInfo();
    }
