    public PositionVM()
    {
        Position = new ObservableCollection<PositionModel>();
        Position.Add(new PositionModel()
        {
            ID = 1,
            PositionName = "asd"
        });
    }
