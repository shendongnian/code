    public static void DisposeIfDisposable(this object obj)
    {
        if (disposable != null)
        {
            disposable.Dispose();
        }
    }
