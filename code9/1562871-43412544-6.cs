    #region MakeItemsLarge Property
    public bool MakeItemsLarge
    {
        get { return (bool)GetValue(MakeItemsLargeProperty); }
        set { SetValue(MakeItemsLargeProperty, value); }
    }
    public static readonly DependencyProperty MakeItemsLargeProperty =
        DependencyProperty.Register(nameof(MakeItemsLarge), typeof(bool), typeof(MovieChooser),
            new PropertyMetadata(false));
    #endregion MakeItemsLarge Property
