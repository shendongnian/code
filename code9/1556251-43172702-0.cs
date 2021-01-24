    private readonly MainWindowViewModel _x;
    public HomeViewModel(MainWindowViewModel x)
    {
        _x = x;
        SelectedReader = new Reader();
        ...
    }
    private void EditBookInfo()
    {
        _x.DisplayBookManagingView();
    }
