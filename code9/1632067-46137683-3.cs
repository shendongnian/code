    public ObservableCollection<ButtonInfo> ButtonInfoCollection { get; } = new ObservableCollection<ButtonInfo>
    {
        new ButtonInfo { MenuName = "New Menu", PageType = typeof(BlankPage1), Symbol = "/Assets/StoreLogo.png" }
    };
    public DelegateCommand<Type> NavigateToPageCommand { get; } = new DelegateCommand<Type>(type => 
        App.Frame.Navigate(type));
