    private bool isChecked;
    public bool IsChecked
    {
        get{ return isChecked || Parent.IsChecked;}
        set
        {
            isChecked = value;
            RaisePropertyChanged("IsChecked");
        }
    }
    public void Parent_PropertyChanged(object sender,PropertyChangedEventArgs e)
    {
        if(e.PropertyName == "IsChecked")
            RaisePropertyChanged("IsChecked");
    }
