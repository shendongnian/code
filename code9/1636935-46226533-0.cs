    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);
        if (e.PropertyName == nameof(Entry.Text)
            || e.PropertyName == nameof(Entry.IsFocused))
        {
            //if there is change in text or focus state - act 
            // i.e hide or show keyboard?
        }
    }
