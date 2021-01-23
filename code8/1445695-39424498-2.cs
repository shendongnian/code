    private static readonly DependencyProperty IsFormValidProperty =
        DependencyProperty.Register(
            "IsFormValid",
            typeof(bool),
            typeof(YourControl),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnValidationChanged))
            );
    
    privatestaticvoid OnValidationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        // here , if e.newValue is true then
        //you can set button's IsEnabled property to true.
    }
