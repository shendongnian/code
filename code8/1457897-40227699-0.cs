    public static readonly DependencyProperty ShowBusyProperty = DependencyProperty.Register("ShowBusy", typeof(Boolean), typeof(FortschrittView), new PropertyMetadata(false, OnShowBusyPropertyChanged));
    public Boolean ShowBusy
    {
        get { return (Boolean)this.GetValue(ShowBusyProperty); }
        set { this.SetValue(ShowBusyProperty, value); }
    }
    private static void OnShowBusyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        FortschrittView myUserControl = dependencyObject as FortschrittView;
        myUserControl.OnPropertyChanged("ShowBusy");
        myUserControl.OnShowBusyPropertyChanged(e);
    }
    private void OnShowBusyPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if(ShowBusy)
        {
            Start();
        }
        else
        {
            Stop();
        }
    }
