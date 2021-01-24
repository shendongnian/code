    public override Task<CancelConfirm> CancelSync(CancelRequest request, ServerCallContext context) {
        var tcs = new TaskCompletionSource<CancelConfirm>();
        EventHandler handler = null;
        handler = (sender, eventArgs) =>
        {
            Program.MyClass.SyncEnd -= handler; //unregister itself
            tcs.SetResult(new CancelConfirm { Cancelled = true });
        };
        Program.MyClass.SyncEnd += handler; //
        Program.MyClass.Cancel();
        return tcs.Task;
    }
