    public PlacementMode TooltipPlacement
    {
        get => (PlacementMode)GetValue(TooltipPlacementProperty);
        set => SetValue(TooltipPlacementProperty, value);
    }
    public static readonly DependencyProperty TooltipPlacementProperty =
        DependencyProperty.Register("TooltipPlacement", typeof(PlacementMode), typeof(ArrowDown), 
            new PropertyMetadata(null, TooltipPlacementChangedCallback));
    private static void TooltipPlacementChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var self = (ArrowDown)d;
        self.CalculateArrowVisibility();
    }
