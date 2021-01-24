    private IDisposable _myDisposable;
    public override void Dispose(bool disposing)
    {
        if (disposing && _myDisposable != null)
            _myDisposable.Dispose();
    }
