    private bool isChecked;
    public bool IsChecked
    {
        get{ return isChecked || Children.Any(c=>IsChecked);}
        set
        {
            isChecked = value;
            RaisePropertyChanged("IsChecked");
            foreach(var child in Children)child.IsChecked
        }
    }
    public void Child_PropertyChanged(object sender,PropertyChangedEventArgs e)
    {
        RaisePropertyChanged("IsChecked");
    }
