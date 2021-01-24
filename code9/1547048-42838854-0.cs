    private bool isBusy;
    public bool IsBusy() {
        get { return isBusy; }
        set { SetProperty(ref isBusy, value); }
    }
