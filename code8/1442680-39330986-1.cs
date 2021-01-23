    public YourViewModel()
            {
                IList<Bar> bars = GetBars().ToList();
                _barView = CollectionViewSource.GetDefaultView(bars);
                _barView.CurrentChanged += BarSelectionChanged;
