    private string _username;
    public bool Username
    {
        get { return _username; }
        set
        {
            string tmp = value;
            _username= tmp.Replace(" ", String.Empty);;
            OnPropertyChanged();
        }
    }
    <Entry Text="{Binding Username}" />
