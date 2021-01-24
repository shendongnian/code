    private void MyClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch(e.PropertyName)
        {
            case "PropertyA":
                RaisePropertyChanged(nameof(PropertyB));
                break;
        }
    }
