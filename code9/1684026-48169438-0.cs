    public MainViewModel()
    {
        var list = new List<MyDataClass>
        {
            new MyDataClass { Description = "Item 01", Quantity = 20, IsSelected = false },
            new MyDataClass { Description = "Item 02", Quantity = 50, IsSelected = false },
            new MyDataClass { Description = "Item 03", Quantity = 60, IsSelected = false }
        };
        foreach (var item in list)
        {
            item.PropertyChanged += OnItemPropertyChanged;
        }
        MyDataList = new ObservableCollection<MyDataClass>(list);
    }
    void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsSelected") OnPropertyChanged(nameof(Amount));
    }
