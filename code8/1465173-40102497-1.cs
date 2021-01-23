    private ContentControlDataModel _CurrentItem;
    
    public ContentControlDataModel CurrentItem
    {
        get { return _CurrentItem; }
        set
        {
            if (value != _CurrentItem)
            {
                _CurrentItem = value;
                OnPropertyChanged();
            }
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName]string propertyName = "")
    {
        if (this.PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = combo.SelectedItem as ComboBoxItem;
        switch (item.Content.ToString())
        {
            case "NullTemplate":
                CurrentItem = new ContentControlDataModel { Template = null, TemplateName = "NullTemplate" };
                break;
    
            case "CustomTemplate1":
                CurrentItem = new ContentControlDataModel { Template = true, TemplateName = "CustomTemplate1" };
                break;
    
            case "CustomTemplate2":
                CurrentItem = new ContentControlDataModel { Template = false, TemplateName = "CustomTemplate2" };
                break;
    
            case "SetCurrentItemToNull":
                CurrentItem = null;
                break;
            case "SetCurrentItemPropertyToNull":
                CurrentItem = new ContentControlDataModel { Template = null, TemplateName = null };
                break;
        }
    }
