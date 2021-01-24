    private ObservableCollection<string> cbItems;
    public ObservableCollection<string> ComboBoxItems
    {
        get
        {
            return this.cbItems;
        }
        set
        {
            this.cbItems = value;
            this.RaisePropertyChanged("ComboBoxItems");
        }
    }
