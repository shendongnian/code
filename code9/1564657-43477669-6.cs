    private Button _compactOverlayButton;
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _compactOverlayButton = GetTemplateChild("CompactOverlayButton") as Button;
        //  Update actual button visibility to match whatever the dependency property value 
        //  is, in case XAML gave us a value for it already. 
        OnIsCompactOverlayButtonVisibleChanged();
        _compactOverlayButton.Click += CompactOverlayButton_Click;
        //  Secondly, just in case something in the XAML may change the button's visibility, 
        //  put a watch on the property and update our dependency property to match when that 
        //  changes. 
        var dpd = DependencyPropertyDescriptor.FromProperty(Button.VisibilityProperty, typeof(Button));
        dpd.AddValueChanged(_compactOverlayButton, CompactOverlayButton_VisibilityChanged);
    }
    protected void CompactOverlayButton_VisibilityChanged(object sender, EventArgs args)
    {
        IsCompactOverlayButtonVisible = _compactOverlayButton.Visibility == Visibility.Visible;
    }
    private void CompactOverlayButton_Click(object sender, RoutedEventArgs e)
    {
        //  ...whatever
    }
    #region IsCompactOverlayButtonVisible Property
    public bool IsCompactOverlayButtonVisible
    {
        get { return (bool)GetValue(IsCompactOverlayButtonVisibleProperty); }
        set { SetValue(IsCompactOverlayButtonVisibleProperty, value); }
    }
    public static readonly DependencyProperty IsCompactOverlayButtonVisibleProperty =
        DependencyProperty.Register(nameof(IsCompactOverlayButtonVisible), typeof(bool), typeof(CustomMediaTransportControls),
            new FrameworkPropertyMetadata(true,
                                            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                            IsCompactOverlayButtonVisible_PropertyChanged));
    protected static void IsCompactOverlayButtonVisible_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //  It's a hassle to do stuff in a static method, so my dependency property 
        //  snippet just creates a private instance method and calls it from the 
        //  static handler. 
        (d as CustomMediaTransportControls).OnIsCompactOverlayButtonVisibleChanged();
    }
    private void OnIsCompactOverlayButtonVisibleChanged()
    {
        if (_compactOverlayButton != null)
        {
            //  If the existing value is the same as the new value, this is a no-op
            _compactOverlayButton.Visibility = 
                IsCompactOverlayButtonVisible
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }
    }
    #endregion IsCompactOverlayButtonVisible Property
