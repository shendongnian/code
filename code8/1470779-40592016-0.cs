    string someText ;
    public string SomeText {
        get { return someText; }
        set { this.RaiseAndSetIfChanged(ref someText , value); }
    }
    
    Status currentStatus;
    public Status CurrentStatus {
        get { return currentStatus; }
        set { this.RaiseAndSetIfChanged(ref currentStatus, value); }
    }
