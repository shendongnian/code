    private static void OnColumnsCountPropertyChanged(
       DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
       PropertyChangedEventHandler h = PropertyChanged;
       if (h != null)
       {
          h(sender, new PropertyChangedEventArgs("Second"));
       }
    }
