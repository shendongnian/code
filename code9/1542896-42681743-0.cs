    public MultipleColumnsSelectorVM()
    {
        Initialize();
        //do this after you have populated the TreeFieldData collection
        foreach (TreeFieldData data in TreeFieldData)
        {
            data.PropertyChanged += OnPropertyChanged;
        }
    }
    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsSelected")
        {
            TreeFieldData data = sender as TreeFieldData;
            if (data.IsSelected && !SelectedFields.Contains(data))
                SelectedFields.Add(data);
            else if (!data.IsSelected && SelectedFields.Contains(data))
                SelectedFields.Remove(data);
        }
    }
