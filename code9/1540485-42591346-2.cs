    public RelayCommand ClickCommandEvent { get; set; }
    
    public SomeClass()
    {
        ClickCommandEvent = new RelayCommand(ClickExecute);
    }
    public void ClickExecute(object param)
    {
        System.Diagnostics.Debug.WriteLine($"Clicked: {param as string}");
        string name = param as string;
        if (name == "Jack")
            HighFive();
    }
