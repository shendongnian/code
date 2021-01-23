    private ObservableCollection<string> users = new ObservableCollection<string>();
    public ObservableCollection<string> Users
    {
        private get { return users; }
        set
        {
            user = value;
            Notify("user");
        }
    }
