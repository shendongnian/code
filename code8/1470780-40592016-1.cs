    readonly ObservableAsPropertyHelper<string> someText;
    public string SomeText{
        get { return someText.Value; }
    }
    readonly ObservableAsPropertyHelper<Status> currentStatus;
    public Status CurrentStatus{
        get { return currentStatus.Value; }
    }
