    private Visibility class1Visibilty = Visibility.Visible;
    public Visibility Class1Visiblity
    {
        get
        {
            return class1Visibilty;
        }
        set
        {
            class1Visibility = value;
            OnNotifyPropertyChanged("Class1Visibility");
        }
    }
    private Visibility class2Visibilty = Visibility.Collapsed;
    public Visibility Class2Visiblity
    {
        get
        {
            return class2Visibilty;
        }
        set
        {
            class2Visibility = value;
            OnNotifyPropertyChanged("Class2Visibility");
        }
    }
    
    private void _numClass_LostFocus(object sender, RoutedEventArgs e)
    {          
        if (_numClass.Value >= 2)
        {
            Class1Visiblity = Visibility.Collapsed;
            Class2Visiblity = Visibility.Visible;
        }
        else
        {
            Class1Visiblity = Visibility.Visible;
            Class2Visiblity = Visibility.Collapsed;
        }
    }
