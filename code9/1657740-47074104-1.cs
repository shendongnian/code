    private volatile bool _stop = false;
    void OnCancelClick()
    {
        _stop = true;
    }
    void WorkerProcess()  //In separate thread
    {
        while (!_stop)
        {
            // do something
        }
    }
