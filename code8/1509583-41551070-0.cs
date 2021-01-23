    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(IList), typeof(MainWindow), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedItemsChanged)));
    private static void OnSelectedItemsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        MainWindow mainWindow = o as MainWindow;
        if (mainWindow != null)
            mainWindow.OnSelectedItemsChanged((IList)e.OldValue, (IList)e.NewValue);
    }
    protected virtual void OnSelectedItemsChanged(IList oldValue, IList newValue)
    {
        // Add your property changed side-effects. Descendants can override as well.
    }
    public IList SelectedItems
    {
        // IMPORTANT: To maintain parity between setting a property in XAML and procedural code, do not touch the getter and setter inside this dependency property!
        get
        {
            return (IList)GetValue(SelectedItemsProperty);
        }
        set
        {
            SetValue(SelectedItemsProperty, value);
        }
    }
