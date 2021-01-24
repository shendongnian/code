    private volatile bool _stop = false;
    void OnCancelClick()
    {
        _stop = true;
    }
    void WorkerProcess()
    {
        while (!_stop)
        {
            // do something
        }
    }
