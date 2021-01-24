    public Visibility CompactOverlayButtonVisibility
    {
        get { return (Visibility)GetValue(CompactOverlayButtonVisibilityProperty); }
        set { SetValue(CompactOverlayButtonVisibilityProperty, value); }
    }
    public static readonly DependencyProperty CompactOverlayButtonVisibilityProperty =
        DependencyProperty.Register(nameof(CompactOverlayButtonVisibility) , typeof(Visibility), typeof(CustomMediaTransportControls), new PropertyMetadata(Visibility.Visible, OnVisibisityChanged));
    internal static void OnVisibisityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e){
        if (((CustomMediaTransportControls)d).compactOverlayButton != null)
        {
            if ((Visibility)e.NewValue != Visibility.Visible)
                ((CustomMediaTransportControls)d).commandBar.PrimaryCommands.Remove(((CustomMediaTransportControls)d).compactOverlayButton);
            else if (!((CustomMediaTransportControls)d).commandBar.PrimaryCommands.Contains(((CustomMediaTransportControls)d).compactOverlayButton))
                ((CustomMediaTransportControls)d).commandBar.PrimaryCommands.Insert(4, ((CustomMediaTransportControls)d).compactOverlayButton);
            ((CustomMediaTransportControls)d).compactOverlayButton.Visibility = Visibility.Visible;
        }
