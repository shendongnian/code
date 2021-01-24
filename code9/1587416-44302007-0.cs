    public static readonly DependencyProperty CurrentItemProperty =
        DependencyProperty.Register(
            "CurrentItem",
            typeof(CityEntity),
            typeof(CustomAutoCompleteBox),
            new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = CurrentItemPropertyChanged
            });
    private static void CurrentItemPropertyChanged(
         DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (CustomAutoCompleteBox)d;
        control.InternalCurrentItem = (CityEntity)e.NewValue;
    }
