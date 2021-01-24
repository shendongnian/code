    public MvxWindowsPage Owner
    {
        get { return (MvxWindowsPage)GetValue(OwnerProperty); }
        set { SetValue(OwnerProperty, value); }
    }
    
    public static readonly DependencyProperty OwnerProperty =
                  DependencyProperty.Register("Owner", typeof(MvxWindowsPage), typeof(NavigationControl), new PropertyMetadata(PropChanged));
    
    public static void PropChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
          var value = e.NewValue; //confirm this isn't null
    }
