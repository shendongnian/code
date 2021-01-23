    public bool IsListeningForCodes
    {
        get { return (bool)GetValue(IsListeningForCodesProperty); }
        set { SetValue(IsListeningForCodesProperty, value); }
    }
    public static readonly DependencyProperty IsListeningForCodesProperty =
        DependencyProperty.Register("IsListeningForCodes", typeof(bool), typeof(BarCodeTextBox), 
        new PropertyMetadata(false, OnIsListeningForCodesChanged));
    static void OnIsListeningForCodesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (BarCodeTextBox)d;
        instance.OnIsListeningForCodesChanged();
    }
    void OnIsListeningForCodesChanged()
    {
        if (IsListeningForCodes)
        {
            IsReadOnly = true;
            PrefixElement.Visibility = Visibility.Collapsed;
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        }
        else
        {
            IsReadOnly = false;
            Focus(FocusState.Keyboard);
            PrefixElement.Visibility = Visibility.Visible;
            Window.Current.CoreWindow.CharacterReceived -= CoreWindow_CharacterReceived;
        }
        Text = string.Empty;
    }
