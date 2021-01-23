    public MenuItem Parent
    {
        get { return _parent; }
        set
        {
            //remove old handler
            if(_parent != null)
                _parent.PropertyChange-=Parent_PropertyChanged;
            _parent = value;
            //add new handler
            if(_parent != null)
                _parent.PropertyChange+=Parent_PropertyChanged;
            RaisePropertyChanged("Parent");
        }
    }
    //handler
    public void Parent_PropertyChanged(object sender,PropertyChangedEventArgs e)
    {
        if(e.PropertyName == "IsChecked")
            RaisePropertyChanged("IsChecked");
    }
