    public DelegateCommand<string> PersonSelectedCommand => new DelegateCommand<string>(OnPersonSelectedCommandExecuted);
    public ObservableRangeCollection<string> People { get; set; }
    void OnPersonSelectedCommandExecuted(string name)
    {
        _pageDialogService.DisplayAlertAsync("Person Selected", name, "Ok" );
    }
