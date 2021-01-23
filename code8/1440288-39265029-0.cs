    private void FetchRecord()
    {
        // try omitted...
        if (Application.Current.Dispatcher.CheckAccess())
        {
            // do work...
        }
        else
        {
            Application.Current.Dispatcher.Invoke(new System.Action(() => FetchRecord()));
        }
    }
