    private ProgressEventHandler ProgressEvent;
    public event ProgressEventHandler Progress
    {
        add
        {
            ProgressEvent += value;
        }
        remove
        {
            ProgressEvent -= value;
        }
    }
