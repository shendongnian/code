    public Network()
    {
        InitializeComponent();
        BindingList = new ObservableCollection<KeyValuePair<string, object>>();
        PrintStatus();
    }
    public ObservableCollection<KeyValuePair<string, object>> BindingList { get; private set; }
    public void PrintStatus()
    {
        BindingList.Clear();
        foreach (NetworkInterface card in networkCards)
        {
            foreach (PropertyInfo prop in typeof(NetworkInterface).GetProperties()) 
            {
                BindingList.Add(new KeyValuePair<string, object>(prop.Name, prop.GetValue(card, null)));
            }
        }
    }
