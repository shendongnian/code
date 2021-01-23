    private ObservableCollection<string> user = new ObservableCollection<string>();
    public ObservableCollection<string> User
    {
        private get { return user; }
        set
        {
            user = value;
            Notify("user");
        }
    }
