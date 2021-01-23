    GridColumns = 9;
    var itemCount = Math.Pow(GridColumns, 2);
    for (var i = 0; i < itemCount; ++i)
    {
        var btn = new GridButton()
        {
            Text = string.Format("{0}x{1}", i % GridColumns + 1, i / GridColumns + 1),
            OnClick = new RelayCommand<GridButton>((b) =>
            {
                b.Background = Brushes.Green;
            }),
            OnRightClick = new RelayCommand<GridButton>((b) =>
            {
                b.Background = Brushes.Red;
            })
        };
        GridButtonList.Add(btn);
    }
