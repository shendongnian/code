    public Circle Circle 
    {
       get { return circle; }
       set {
           circle = value;
           if (circle != null) 
               circle.PropertyChanged += OnPropertyChanged;
       }
    }
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Some Property of Circle")
            // Do something to Line
    }
