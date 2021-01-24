    //update the ui
    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
    {
        foreach (var item in items)
        {
            Items.Add(item);
        }
        if (items.Any())
        {
            SelectedItem = items.First();
            NotifyOfPropertyChange(() => SelectedItem);
        }
    }));
