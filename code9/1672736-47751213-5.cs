    private string executionStatus = string.Empty;
    public string ExecutionStatus
    {
        get { return executionStatus; }
        set
        {
            executionStatus = value;
            RaisePropertyChanged(nameof(ExecutionStatus));
        }
    }
    private bool canRun = true;
    public bool CanRun
    {
        get { return canRun; }
        set
        {
            canRun = value;
            RaisePropertyChanged(nameof(CanRun));
        }
    }
