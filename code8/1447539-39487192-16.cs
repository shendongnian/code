    public MenuItem Parent
    {
        get { return _parent; }
        set
        {
            //remove old handler
            // this stops listening to the old parent if there is one
            if(_parent != null)
                _parent.PropertyChange-=Parent_PropertyChanged;
            //notice that the value of _parent changes here so _parent above is not the same as _parent used below
            _parent = value;
            //add new handler
            // this starts listening to the new parent if there is one
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
