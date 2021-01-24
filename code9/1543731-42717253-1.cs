    private object pageViewModel;
    public object PageViewModel
    {
        get { return pageViewModel; }
        set
        {
            pageViewModel = value;
            OnPropertyChanged();
            MyCommand.Execute(null);
        }
    }
