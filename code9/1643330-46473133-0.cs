    public void OnChildModelPropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName != "ThePropertyName")
            return;
        //try grouping GroupViewModel
        //do some tasks which takes little over time
    }
